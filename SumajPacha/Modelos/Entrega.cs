using System;

namespace SumajPacha.Presentacion
{
    public class Entrega
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public Parcela Parcela { get; set; }
        public string Insumo { get; set; }
        public string Cultivo { get; set; } // queda vacío cuando el insumo es abono
        public decimal Cantidad { get; set; }
        public string Unidad { get; set; }
        public string Tecnico { get; set; }

        // las entregas no se borran, solo se anulan
        public bool Anulada { get; set; }
        public string AnuladaPor { get; set; }
        public DateTime? FechaAnulacion { get; set; }

        public string Estado
        {
            get
            {
                if (Anulada)
                    return "Anulada";
                return "Vigente";
            }
        }
    }
}
