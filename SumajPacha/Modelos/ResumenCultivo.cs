namespace SumajPacha.Presentacion
{
    // fila del reporte de supervivencia por cultivo
    public class ResumenCultivo
    {
        public string Cultivo { get; set; }
        public int Entregados { get; set; }
        public int Vivas { get; set; }

        public double Porcentaje()
        {
            return Calculos.Supervivencia(Vivas, Entregados);
        }
    }
}
