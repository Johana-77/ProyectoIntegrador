using System;

namespace SumajPacha.Presentacion
{
    public class Parcela
    {
        public int Id { get; set; } // id_parcela en la base de datos
        public string Codigo { get; set; }
        public Familia Familia { get; set; }
        public string Proyecto { get; set; }
        public string Tipo { get; set; }
        public decimal Superficie { get; set; } // en m2
        public bool TieneRiego { get; set; }
        public DateTime FechaInstalacion { get; set; }
        public string Estado { get; set; } // cambia con cada visita técnica

        public override string ToString()
        {
            return Codigo + " - " + Familia.Apellidos;
        }
    }
}
