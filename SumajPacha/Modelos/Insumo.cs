namespace SumajPacha.Presentacion
{
    // lo que se entrega a las familias: plantines, abono o bioinsumo
    public class Insumo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Tipo { get; set; } // PLANTIN, ABONO o BIOINSUMO
        public string Cultivo { get; set; } // solo los plantines tienen cultivo
        public string Unidad { get; set; }
    }
}
