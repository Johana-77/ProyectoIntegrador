namespace SumajPacha.Presentacion
{
    public class Familia
    {
        public int Id { get; set; } // id_familia en la base de datos
        public string Codigo { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Comunidad { get; set; }
        public string Sexo { get; set; } // Mujer u Hombre
        public int Edad { get; set; }
        public int Miembros { get; set; }
        public bool Activa { get; set; } // por ahora todas las familias estan activas

        public string NombreCompleto()
        {
            return Nombres + " " + Apellidos;
        }

        public override string ToString()
        {
            return Codigo + " - " + Apellidos;
        }
    }
}
