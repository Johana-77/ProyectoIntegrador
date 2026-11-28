using System;
using System.Collections.Generic;

namespace SumajPacha.Presentacion
{
    public class Visita
    {
        public int Id { get; set; }
        public Parcela Parcela { get; set; }
        public DateTime Fecha { get; set; }
        public string EstadoParcela { get; set; }
        public string Observacion { get; set; }
        public string Tecnico { get; set; }
        public List<DetalleVisita> Detalles { get; set; }

        public Visita()
        {
            Detalles = new List<DetalleVisita>();
        }

        public int TotalEntregados()
        {
            int total = 0;
            foreach (DetalleVisita d in Detalles)
                total += d.Entregados;
            return total;
        }

        public int TotalVivas()
        {
            int total = 0;
            foreach (DetalleVisita d in Detalles)
                total += d.Vivas;
            return total;
        }

        public decimal TotalKg()
        {
            decimal total = 0;
            foreach (DetalleVisita d in Detalles)
                total += d.KgCosechados;
            return total;
        }

        public double Supervivencia()
        {
            return Calculos.Supervivencia(TotalVivas(), TotalEntregados());
        }
    }

    public class DetalleVisita
    {
        public string Cultivo { get; set; }
        public int Entregados { get; set; }
        public int Vivas { get; set; }
        public decimal KgCosechados { get; set; }
    }
}
