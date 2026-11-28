namespace SumajPacha.Presentacion
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; } // se guarda el hash, no la contraseña
        public string Rol { get; set; } // Administrador, Técnico o Consulta
        public string Perfil { get; set; }
        public bool Activo { get; set; }

        public string PrimerNombre()
        {
            return Nombre.Split(' ')[0];
        }
    }
}
