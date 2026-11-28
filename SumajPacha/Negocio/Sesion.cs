using System;

namespace SumajPacha.Presentacion
{
    // guarda el usuario que inicio sesion para usarlo en las demas pantallas
    // roles: Administrador, Técnico y Consulta
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; private set; }
        public static DateTime Inicio { get; private set; }

        public static void Iniciar(Usuario usuario)
        {
            UsuarioActual = usuario;
            Inicio = DateTime.Now;
        }

        public static void Cerrar()
        {
            UsuarioActual = null;
        }

        public static bool EsAdministrador()
        {
            return UsuarioActual != null && UsuarioActual.Rol == "Administrador";
        }

        // el rol Consulta solo puede ver el inicio y los reportes
        public static bool EsConsulta()
        {
            return UsuarioActual != null && UsuarioActual.Rol == "Consulta";
        }
    }
}
