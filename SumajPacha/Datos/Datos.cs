using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;

namespace SumajPacha.Presentacion
{
    // aqui estan las consultas a la base de datos SumajPachaDB
    // al abrir el sistema se cargan las tablas en estas listas y las pantallas usan las listas
    // cuando se registra algo primero se guarda en la base y despues se agrega a la lista
    public static class Datos
    {
        public static List<Usuario> Usuarios = new List<Usuario>();
        public static List<Familia> Familias = new List<Familia>();
        public static List<Parcela> Parcelas = new List<Parcela>();
        public static List<Cultivo> Cultivos = new List<Cultivo>();
        public static List<Insumo> Insumos = new List<Insumo>();
        public static List<string> Comunidades = new List<string>();
        public static List<string> Proyectos = new List<string>();
        public static List<Entrega> Entregas = new List<Entrega>();
        public static List<Visita> Visitas = new List<Visita>();

        // para saber el id de cada proyecto cuando se guarda una parcela
        private static Dictionary<string, int> idProyectos = new Dictionary<string, int>();

        // --- cargar los datos de la base ---

        public static void Cargar()
        {
            Usuarios.Clear();
            Familias.Clear();
            Parcelas.Clear();
            Cultivos.Clear();
            Insumos.Clear();
            Comunidades.Clear();
            Proyectos.Clear();
            Entregas.Clear();
            Visitas.Clear();
            idProyectos.Clear();

            using (SqlConnection cn = Conexion.Abrir())
            {
                CargarUsuarios(cn);
                CargarCatalogos(cn);
                CargarFamilias(cn);
                CargarParcelas(cn);
                CargarEntregas(cn);
                CargarVisitas(cn);
            }

            // el estado de cada parcela es el de su última visita
            foreach (Parcela p in Parcelas)
            {
                Visita ultima = UltimaVisita(p);
                if (ultima != null)
                    p.Estado = ultima.EstadoParcela;
                else
                    p.Estado = "Sin visita";
            }
        }

        private static void CargarUsuarios(SqlConnection cn)
        {
            string sql = "SELECT id_usuario, nombre, cargo, usuario, contrasena_hash, rol, activo "
                + "FROM USUARIO ORDER BY id_usuario";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Usuario u = new Usuario();
                    u.Id = Convert.ToInt32(dr["id_usuario"]);
                    u.Nombre = dr["nombre"].ToString();
                    u.Perfil = dr["cargo"].ToString();
                    u.NombreUsuario = dr["usuario"].ToString();
                    u.Contrasena = dr["contrasena_hash"].ToString();
                    u.Rol = RolDesdeBase(dr["rol"].ToString());
                    u.Activo = Convert.ToBoolean(dr["activo"]);
                    Usuarios.Add(u);
                }
            }
        }

        private static void CargarCatalogos(SqlConnection cn)
        {
            using (SqlCommand cmd = new SqlCommand("SELECT nombre FROM COMUNIDAD ORDER BY nombre", cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                    Comunidades.Add(dr["nombre"].ToString());
            }

            using (SqlCommand cmd = new SqlCommand("SELECT id_proyecto, nombre FROM PROYECTO ORDER BY id_proyecto", cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    string nombre = dr["nombre"].ToString();
                    Proyectos.Add(nombre);
                    idProyectos[nombre] = Convert.ToInt32(dr["id_proyecto"]);
                }
            }

            string sqlCultivos = "SELECT id_cultivo, nombre, dias_a_cosecha, precio_ref_kg "
                + "FROM CULTIVO ORDER BY id_cultivo";
            using (SqlCommand cmd = new SqlCommand(sqlCultivos, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Cultivo c = new Cultivo();
                    c.Id = Convert.ToInt32(dr["id_cultivo"]);
                    c.Nombre = dr["nombre"].ToString();
                    c.DiasCosecha = Convert.ToInt32(dr["dias_a_cosecha"]);
                    c.PrecioReferencia = Convert.ToDecimal(dr["precio_ref_kg"]);
                    Cultivos.Add(c);
                }
            }

            string sqlInsumos = "SELECT I.id_insumo, I.nombre, I.tipo, I.unidad_medida, C.nombre AS cultivo "
                + "FROM INSUMO I LEFT JOIN CULTIVO C ON C.id_cultivo = I.id_cultivo "
                + "ORDER BY I.id_insumo";
            using (SqlCommand cmd = new SqlCommand(sqlInsumos, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Insumo i = new Insumo();
                    i.Id = Convert.ToInt32(dr["id_insumo"]);
                    i.Nombre = dr["nombre"].ToString();
                    i.Tipo = dr["tipo"].ToString();
                    i.Unidad = dr["unidad_medida"].ToString();
                    if (dr["cultivo"] == DBNull.Value)
                        i.Cultivo = null;
                    else
                        i.Cultivo = dr["cultivo"].ToString();
                    Insumos.Add(i);
                }
            }
        }

        private static void CargarFamilias(SqlConnection cn)
        {
            string sql = "SELECT F.id_familia, F.nombres, F.apellidos, F.sexo, F.fecha_nacimiento, "
                + "F.nro_miembros, C.nombre AS comunidad "
                + "FROM FAMILIA F JOIN COMUNIDAD C ON C.id_comunidad = F.id_comunidad "
                + "ORDER BY F.id_familia";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Familia f = new Familia();
                    f.Id = Convert.ToInt32(dr["id_familia"]);
                    f.Codigo = "F-" + f.Id.ToString("00");
                    f.Nombres = dr["nombres"].ToString();
                    f.Apellidos = dr["apellidos"].ToString();
                    f.Comunidad = dr["comunidad"].ToString();
                    f.Sexo = SexoDesdeBase(dr["sexo"].ToString());
                    f.Edad = CalcularEdad(Convert.ToDateTime(dr["fecha_nacimiento"]));
                    f.Miembros = Convert.ToInt32(dr["nro_miembros"]);
                    f.Activa = true;
                    Familias.Add(f);
                }
            }
        }

        private static void CargarParcelas(SqlConnection cn)
        {
            string sql = "SELECT P.id_parcela, P.id_familia, PR.nombre AS proyecto, P.tipo, P.superficie_m2, "
                + "P.tiene_riego, P.fecha_instalacion "
                + "FROM PARCELA P JOIN PROYECTO PR ON PR.id_proyecto = P.id_proyecto "
                + "ORDER BY P.id_parcela";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Parcela p = new Parcela();
                    p.Id = Convert.ToInt32(dr["id_parcela"]);
                    p.Codigo = "P-" + p.Id.ToString("00");
                    p.Familia = BuscarFamiliaPorId(Convert.ToInt32(dr["id_familia"]));
                    p.Proyecto = dr["proyecto"].ToString();
                    p.Tipo = TipoDesdeBase(dr["tipo"].ToString());
                    p.Superficie = Convert.ToDecimal(dr["superficie_m2"]);
                    p.TieneRiego = Convert.ToBoolean(dr["tiene_riego"]);
                    p.FechaInstalacion = Convert.ToDateTime(dr["fecha_instalacion"]);
                    Parcelas.Add(p);
                }
            }
        }

        private static void CargarEntregas(SqlConnection cn)
        {
            string sql = "SELECT E.id_entrega, E.id_parcela, E.id_insumo, E.fecha, E.cantidad, E.anulado, "
                + "E.fecha_anulacion, U.nombre AS tecnico, UA.nombre AS anulado_por "
                + "FROM ENTREGA E "
                + "JOIN USUARIO U ON U.id_usuario = E.id_usuario "
                + "LEFT JOIN USUARIO UA ON UA.id_usuario = E.id_usuario_anula "
                + "ORDER BY E.fecha, E.id_entrega";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Entrega e = new Entrega();
                    e.Id = Convert.ToInt32(dr["id_entrega"]);
                    e.Parcela = BuscarParcelaPorId(Convert.ToInt32(dr["id_parcela"]));
                    e.Fecha = Convert.ToDateTime(dr["fecha"]);
                    e.Cantidad = Convert.ToDecimal(dr["cantidad"]);
                    e.Tecnico = dr["tecnico"].ToString();

                    // por ejemplo "Plantines de brócoli" o el nombre del abono
                    Insumo insumo = BuscarInsumoPorId(Convert.ToInt32(dr["id_insumo"]));
                    if (insumo.Tipo == "PLANTIN" && insumo.Cultivo != null)
                    {
                        e.Insumo = "Plantines de " + insumo.Cultivo;
                        e.Cultivo = insumo.Cultivo;
                        e.Unidad = "plantines";
                    }
                    else
                    {
                        e.Insumo = insumo.Nombre;
                        e.Cultivo = null;
                        e.Unidad = insumo.Unidad;
                    }

                    e.Anulada = Convert.ToBoolean(dr["anulado"]);
                    if (dr["anulado_por"] != DBNull.Value)
                        e.AnuladaPor = dr["anulado_por"].ToString();
                    if (dr["fecha_anulacion"] != DBNull.Value)
                        e.FechaAnulacion = Convert.ToDateTime(dr["fecha_anulacion"]);

                    Entregas.Add(e);
                }
            }
        }

        private static void CargarVisitas(SqlConnection cn)
        {
            // las visitas anuladas no se muestran
            string sql = "SELECT V.id_visita, V.id_parcela, V.fecha, V.estado_parcela, V.observacion, "
                + "U.nombre AS tecnico "
                + "FROM VISITA V JOIN USUARIO U ON U.id_usuario = V.id_usuario "
                + "WHERE V.anulado = 0 "
                + "ORDER BY V.fecha, V.id_visita";

            using (SqlCommand cmd = new SqlCommand(sql, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Visita v = new Visita();
                    v.Id = Convert.ToInt32(dr["id_visita"]);
                    v.Parcela = BuscarParcelaPorId(Convert.ToInt32(dr["id_parcela"]));
                    v.Fecha = Convert.ToDateTime(dr["fecha"]);
                    v.EstadoParcela = EstadoDesdeBase(dr["estado_parcela"].ToString());
                    v.Observacion = dr["observacion"].ToString(); // si es NULL queda ""
                    v.Tecnico = dr["tecnico"].ToString();
                    Visitas.Add(v);
                }
            }

            // plantas vivas y kg cosechados de cada cultivo en cada visita
            string sqlDetalle = "SELECT SC.id_visita, C.nombre AS cultivo, SC.plantas_vivas, SC.kg_cosechados "
                + "FROM SEGUIMIENTO_CULTIVO SC JOIN CULTIVO C ON C.id_cultivo = SC.id_cultivo "
                + "ORDER BY SC.id_seguimiento";

            using (SqlCommand cmd = new SqlCommand(sqlDetalle, cn))
            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    Visita v = BuscarVisitaPorId(Convert.ToInt32(dr["id_visita"]));
                    if (v == null)
                        continue; // visita anulada

                    DetalleVisita d = new DetalleVisita();
                    d.Cultivo = dr["cultivo"].ToString();
                    d.Vivas = Convert.ToInt32(dr["plantas_vivas"]);
                    d.KgCosechados = Convert.ToDecimal(dr["kg_cosechados"]);
                    // los entregados se cuentan hasta el día de la visita
                    d.Entregados = PlantinesEntregados(v.Parcela, d.Cultivo, v.Fecha);
                    v.Detalles.Add(d);
                }
            }
        }

        // --- busquedas en las listas ---

        public static Usuario BuscarUsuario(string nombreUsuario)
        {
            foreach (Usuario u in Usuarios)
            {
                if (u.NombreUsuario.ToLower() == nombreUsuario.Trim().ToLower())
                    return u;
            }
            return null;
        }

        public static Familia BuscarFamilia(string codigo)
        {
            foreach (Familia f in Familias)
            {
                if (f.Codigo == codigo)
                    return f;
            }
            return null;
        }

        public static Parcela BuscarParcela(string codigo)
        {
            foreach (Parcela p in Parcelas)
            {
                if (p.Codigo == codigo)
                    return p;
            }
            return null;
        }

        public static Cultivo BuscarCultivo(string nombre)
        {
            foreach (Cultivo c in Cultivos)
            {
                if (c.Nombre.ToLower() == nombre.Trim().ToLower())
                    return c;
            }
            return null;
        }

        // insumo de plantines de un cultivo (por ejemplo "Plantín de brócoli")
        public static Insumo BuscarInsumoPlantin(string cultivo)
        {
            foreach (Insumo i in Insumos)
            {
                if (i.Tipo == "PLANTIN" && i.Cultivo != null && i.Cultivo.ToLower() == cultivo.ToLower())
                    return i;
            }
            return null;
        }

        public static Insumo BuscarInsumo(string nombre)
        {
            foreach (Insumo i in Insumos)
            {
                if (i.Nombre == nombre)
                    return i;
            }
            return null;
        }

        private static Familia BuscarFamiliaPorId(int id)
        {
            foreach (Familia f in Familias)
            {
                if (f.Id == id)
                    return f;
            }
            return null;
        }

        private static Parcela BuscarParcelaPorId(int id)
        {
            foreach (Parcela p in Parcelas)
            {
                if (p.Id == id)
                    return p;
            }
            return null;
        }

        private static Visita BuscarVisitaPorId(int id)
        {
            foreach (Visita v in Visitas)
            {
                if (v.Id == id)
                    return v;
            }
            return null;
        }

        private static Insumo BuscarInsumoPorId(int id)
        {
            foreach (Insumo i in Insumos)
            {
                if (i.Id == id)
                    return i;
            }
            return null;
        }

        public static List<Parcela> ParcelasDeFamilia(Familia familia)
        {
            List<Parcela> lista = new List<Parcela>();
            foreach (Parcela p in Parcelas)
            {
                if (p.Familia == familia)
                    lista.Add(p);
            }
            return lista;
        }

        public static Visita UltimaVisita(Parcela parcela)
        {
            Visita ultima = null;
            foreach (Visita v in Visitas)
            {
                if (v.Parcela != parcela)
                    continue;
                if (ultima == null || v.Fecha > ultima.Fecha || (v.Fecha == ultima.Fecha && v.Id > ultima.Id))
                    ultima = v;
            }
            return ultima;
        }

        // la próxima visita es 15 días después de la última (o de la instalación)
        public static DateTime ProximaVisita(Parcela parcela)
        {
            Visita ultima = UltimaVisita(parcela);
            if (ultima != null)
                return ultima.Fecha.AddDays(Calculos.DIAS_ENTRE_VISITAS);
            return parcela.FechaInstalacion.AddDays(Calculos.DIAS_ENTRE_VISITAS);
        }

        // suma los plantines entregados de un cultivo (sin contar las entregas anuladas)
        public static int PlantinesEntregados(Parcela parcela, string cultivo)
        {
            return PlantinesEntregados(parcela, cultivo, DateTime.MaxValue);
        }

        // lo mismo, pero solo las entregas hasta una fecha
        public static int PlantinesEntregados(Parcela parcela, string cultivo, DateTime hasta)
        {
            int total = 0;
            foreach (Entrega e in Entregas)
            {
                if (e.Parcela == parcela && !e.Anulada && e.Cultivo == cultivo && e.Fecha <= hasta)
                    total += (int)e.Cantidad;
            }
            return total;
        }

        public static List<string> CultivosEntregados(Parcela parcela)
        {
            List<string> lista = new List<string>();
            foreach (Cultivo c in Cultivos)
            {
                if (PlantinesEntregados(parcela, c.Nombre) > 0)
                    lista.Add(c.Nombre);
            }
            return lista;
        }

        // --- guardar en la base ---
        // si algo falla se lanza el error y la pantalla lo muestra con un try/catch

        // --- usuarios ---

        public static void RegistrarUsuario(Usuario usuario)
        {
            string sql = "INSERT INTO USUARIO (nombre, cargo, usuario, contrasena_hash, rol, activo) "
                + "VALUES (@nombre, @cargo, @usuario, @hash, @rol, @activo); "
                + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@nombre", usuario.Nombre);
                cmd.Parameters.AddWithValue("@cargo", usuario.Perfil ?? "");
                cmd.Parameters.AddWithValue("@usuario", usuario.NombreUsuario);
                cmd.Parameters.AddWithValue("@hash", usuario.Contrasena);
                cmd.Parameters.AddWithValue("@rol", RolParaBase(usuario.Rol));
                cmd.Parameters.AddWithValue("@activo", usuario.Activo);
                usuario.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            Usuarios.Add(usuario);
        }

        public static void ActualizarUsuario(Usuario usuario, string nombre, string nombreUsuario,
            string hashContrasena, string rol, string perfil)
        {
            string sql = "UPDATE USUARIO SET nombre = @nombre, cargo = @cargo, usuario = @usuario, "
                + "contrasena_hash = @hash, rol = @rol WHERE id_usuario = @id";

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@cargo", perfil ?? "");
                cmd.Parameters.AddWithValue("@usuario", nombreUsuario);
                cmd.Parameters.AddWithValue("@hash", hashContrasena);
                cmd.Parameters.AddWithValue("@rol", RolParaBase(rol));
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            usuario.Nombre = nombre;
            usuario.NombreUsuario = nombreUsuario;
            usuario.Contrasena = hashContrasena;
            usuario.Rol = rol;
            usuario.Perfil = perfil;
        }

        public static void CambiarEstadoUsuario(Usuario usuario, bool activo)
        {
            using (SqlConnection cn = Conexion.Abrir())
            using (SqlCommand cmd = new SqlCommand("UPDATE USUARIO SET activo = @activo WHERE id_usuario = @id", cn))
            {
                cmd.Parameters.AddWithValue("@activo", activo);
                cmd.Parameters.AddWithValue("@id", usuario.Id);
                cmd.ExecuteNonQuery();
            }

            usuario.Activo = activo;
        }

        // --- cultivos ---

        // guarda el cultivo y también su insumo "Plantín de ..." para poder entregarlo
        public static void RegistrarCultivo(Cultivo cultivo)
        {
            Insumo plantin;

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                string sql = "INSERT INTO CULTIVO (nombre, dias_a_cosecha, precio_ref_kg) "
                    + "VALUES (@nombre, @dias, @precio); "
                    + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(sql, cn, tx))
                {
                    cmd.Parameters.AddWithValue("@nombre", cultivo.Nombre);
                    cmd.Parameters.AddWithValue("@dias", cultivo.DiasCosecha);
                    cmd.Parameters.AddWithValue("@precio", cultivo.PrecioReferencia);
                    cultivo.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                plantin = CrearInsumoPlantin(cn, tx, cultivo);
                tx.Commit();
            }

            Cultivos.Add(cultivo);
            Insumos.Add(plantin);
        }

        private static Insumo CrearInsumoPlantin(SqlConnection cn, SqlTransaction tx, Cultivo cultivo)
        {
            Insumo plantin = new Insumo();
            plantin.Nombre = "Plantín de " + cultivo.Nombre.ToLower();
            plantin.Tipo = "PLANTIN";
            plantin.Cultivo = cultivo.Nombre;
            plantin.Unidad = "unidad";

            string sql = "INSERT INTO INSUMO (id_cultivo, nombre, tipo, unidad_medida, costo_unitario, es_organico) "
                + "VALUES (@cultivo, @nombre, 'PLANTIN', 'unidad', 0, 1); "
                + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlCommand cmd = new SqlCommand(sql, cn, tx))
            {
                cmd.Parameters.AddWithValue("@cultivo", cultivo.Id);
                cmd.Parameters.AddWithValue("@nombre", plantin.Nombre);
                plantin.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return plantin;
        }

        // --- parcelas ---

        public static void RegistrarParcela(Parcela parcela)
        {
            int idProyecto;
            if (!idProyectos.TryGetValue(parcela.Proyecto, out idProyecto))
                throw new Exception("El proyecto \"" + parcela.Proyecto + "\" no existe en la tabla PROYECTO.");

            string sql = "INSERT INTO PARCELA (id_familia, id_proyecto, tipo, superficie_m2, tiene_riego, fecha_instalacion) "
                + "VALUES (@familia, @proyecto, @tipo, @superficie, @riego, @fecha); "
                + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@familia", parcela.Familia.Id);
                cmd.Parameters.AddWithValue("@proyecto", idProyecto);
                cmd.Parameters.AddWithValue("@tipo", TipoParaBase(parcela.Tipo));
                cmd.Parameters.AddWithValue("@superficie", parcela.Superficie);
                cmd.Parameters.AddWithValue("@riego", parcela.TieneRiego);
                cmd.Parameters.AddWithValue("@fecha", parcela.FechaInstalacion);
                parcela.Id = Convert.ToInt32(cmd.ExecuteScalar());
            }

            parcela.Codigo = "P-" + parcela.Id.ToString("00");
            Parcelas.Add(parcela);
        }

        // --- entregas ---

        public static void RegistrarEntrega(Entrega entrega)
        {
            Insumo insumo;
            Insumo insumoNuevo = null;

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                if (entrega.Cultivo != null)
                {
                    insumo = BuscarInsumoPlantin(entrega.Cultivo);
                    if (insumo == null)
                    {
                        // el cultivo todavía no tenía su insumo de plantines: se crea
                        Cultivo cultivo = BuscarCultivo(entrega.Cultivo);
                        if (cultivo == null)
                            throw new Exception("El cultivo \"" + entrega.Cultivo + "\" no está en el catálogo.");
                        insumoNuevo = CrearInsumoPlantin(cn, tx, cultivo);
                        insumo = insumoNuevo;
                    }
                }
                else
                {
                    insumo = BuscarInsumo(entrega.Insumo);
                    if (insumo == null)
                        throw new Exception("El insumo \"" + entrega.Insumo + "\" no está en la tabla INSUMO.");
                }

                string sql = "INSERT INTO ENTREGA (id_parcela, id_insumo, id_usuario, fecha, cantidad) "
                    + "VALUES (@parcela, @insumo, @usuario, @fecha, @cantidad); "
                    + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                using (SqlCommand cmd = new SqlCommand(sql, cn, tx))
                {
                    cmd.Parameters.AddWithValue("@parcela", entrega.Parcela.Id);
                    cmd.Parameters.AddWithValue("@insumo", insumo.Id);
                    cmd.Parameters.AddWithValue("@usuario", Sesion.UsuarioActual.Id);
                    cmd.Parameters.AddWithValue("@fecha", entrega.Fecha);
                    cmd.Parameters.AddWithValue("@cantidad", entrega.Cantidad);
                    entrega.Id = Convert.ToInt32(cmd.ExecuteScalar());
                }

                tx.Commit();
            }

            if (insumoNuevo != null)
                Insumos.Add(insumoNuevo);
            Entregas.Add(entrega);
        }

        // la entrega no se borra, solo se marca como anulada y se guarda quien y cuando
        public static void AnularEntrega(Entrega entrega, Usuario quienAnula)
        {
            string sql = "UPDATE ENTREGA SET anulado = 1, id_usuario_anula = @usuario, fecha_anulacion = GETDATE() "
                + "WHERE id_entrega = @id";

            using (SqlConnection cn = Conexion.Abrir())
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.AddWithValue("@usuario", quienAnula.Id);
                cmd.Parameters.AddWithValue("@id", entrega.Id);
                cmd.ExecuteNonQuery();
            }

            entrega.Anulada = true;
            entrega.AnuladaPor = quienAnula.Nombre;
            entrega.FechaAnulacion = DateTime.Now;
        }

        // --- visitas ---

        // guarda la visita, las plantas vivas de cada cultivo y, si hace falta, la alerta
        public static void RegistrarVisita(Visita visita)
        {
            using (SqlConnection cn = Conexion.Abrir())
            using (SqlTransaction tx = cn.BeginTransaction())
            {
                string sqlVisita = "INSERT INTO VISITA (id_parcela, id_usuario, fecha, estado_parcela, observacion) "
                    + "VALUES (@parcela, @usuario, @fecha, @estado, @observacion); "
                    + "SELECT CAST(SCOPE_IDENTITY() AS INT);";

                int idVisita;
                using (SqlCommand cmd = new SqlCommand(sqlVisita, cn, tx))
                {
                    cmd.Parameters.AddWithValue("@parcela", visita.Parcela.Id);
                    cmd.Parameters.AddWithValue("@usuario", Sesion.UsuarioActual.Id);
                    cmd.Parameters.AddWithValue("@fecha", visita.Fecha);
                    cmd.Parameters.AddWithValue("@estado", visita.EstadoParcela.ToUpper());
                    if (string.IsNullOrEmpty(visita.Observacion))
                        cmd.Parameters.AddWithValue("@observacion", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@observacion", visita.Observacion);
                    idVisita = Convert.ToInt32(cmd.ExecuteScalar());
                }

                string sqlDetalle = "INSERT INTO SEGUIMIENTO_CULTIVO (id_visita, id_cultivo, plantas_vivas, kg_cosechados) "
                    + "VALUES (@visita, @cultivo, @vivas, @kg)";

                foreach (DetalleVisita d in visita.Detalles)
                {
                    Cultivo cultivo = BuscarCultivo(d.Cultivo);
                    if (cultivo == null)
                        throw new Exception("El cultivo \"" + d.Cultivo + "\" no está en el catálogo.");

                    using (SqlCommand cmd = new SqlCommand(sqlDetalle, cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@visita", idVisita);
                        cmd.Parameters.AddWithValue("@cultivo", cultivo.Id);
                        cmd.Parameters.AddWithValue("@vivas", d.Vivas);
                        cmd.Parameters.AddWithValue("@kg", d.KgCosechados);
                        cmd.ExecuteNonQuery();
                    }
                }

                // alerta MEDIO si es menos de 81%, CRITICO si es menos de 72% (en pantalla sale como ALTO)
                double supervivencia = visita.Supervivencia();
                string nivel = Calculos.NivelAlerta(supervivencia);
                if (nivel != "")
                {
                    string sqlAlerta = "INSERT INTO ALERTA (id_visita, supervivencia, umbral_aplicado, nivel_riesgo) "
                        + "VALUES (@visita, @supervivencia, @umbral, @nivel)";

                    using (SqlCommand cmd = new SqlCommand(sqlAlerta, cn, tx))
                    {
                        cmd.Parameters.AddWithValue("@visita", idVisita);
                        cmd.Parameters.AddWithValue("@supervivencia", Math.Round((decimal)supervivencia, 2));
                        if (nivel == "ALTO")
                        {
                            cmd.Parameters.AddWithValue("@umbral", (decimal)Calculos.UMBRAL_ALTO);
                            cmd.Parameters.AddWithValue("@nivel", "CRITICO");
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@umbral", (decimal)Calculos.UMBRAL_MEDIO);
                            cmd.Parameters.AddWithValue("@nivel", "MEDIO");
                        }
                        cmd.ExecuteNonQuery();
                    }
                }

                tx.Commit();
                visita.Id = idVisita;
            }

            Visitas.Add(visita);
            visita.Parcela.Estado = visita.EstadoParcela;
        }

        // --- conversiones entre la base y las pantallas ---

        // ADMIN = Administrador, TECNICO = Técnico, CONSULTA = Consulta
        private static string RolDesdeBase(string rol)
        {
            switch (rol)
            {
                case "ADMIN": return "Administrador";
                case "TECNICO": return "Técnico";
                case "CONSULTA": return "Consulta";
                default: return rol;
            }
        }

        private static string RolParaBase(string rol)
        {
            switch (rol)
            {
                case "Administrador": return "ADMIN";
                case "Técnico": return "TECNICO";
                case "Consulta": return "CONSULTA";
                default: return rol;
            }
        }

        // F = Mujer, M = Hombre
        private static string SexoDesdeBase(string sexo)
        {
            if (sexo.Trim() == "F")
                return "Mujer";
            return "Hombre";
        }

        // HUERTO o SAF, como sale en la lista de la pantalla
        private static string TipoDesdeBase(string tipo)
        {
            if (tipo == "SAF")
                return "Sistema agroforestal (SAF)";
            return "Huerto familiar";
        }

        private static string TipoParaBase(string tipo)
        {
            if (tipo.Contains("SAF"))
                return "SAF";
            return "HUERTO";
        }

        // BUENO a Bueno
        private static string EstadoDesdeBase(string estado)
        {
            if (estado == "")
                return estado;
            return estado.Substring(0, 1) + estado.Substring(1).ToLower();
        }

        // en la tabla esta la fecha de nacimiento y en las pantallas se muestra la edad
        private static int CalcularEdad(DateTime nacimiento)
        {
            int edad = DateTime.Today.Year - nacimiento.Year;
            if (nacimiento.Date > DateTime.Today.AddYears(-edad))
                edad--;
            return edad;
        }
    }
}
