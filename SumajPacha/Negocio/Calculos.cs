namespace SumajPacha.Presentacion
{
    // calculos del modelo matematico
    // supervivencia = plantas vivas / plantines entregados * 100
    public static class Calculos
    {
        public const double UMBRAL_MEDIO = 81; // menos de 81% es alerta media
        public const double UMBRAL_ALTO = 72; // menos de 72% es alerta alta
        public const int DIAS_ENTRE_VISITAS = 15; // cada cuantos dias se visita una parcela

        // kg de CO2 que se evitan por cada kg cosechado en el huerto (valor de referencia)
        public const double FACTOR_CO2 = 0.5;

        public static double Supervivencia(int vivas, int entregados)
        {
            if (entregados <= 0)
                return 0;
            return vivas * 100.0 / entregados;
        }

        public static string NivelAlerta(double supervivencia)
        {
            if (supervivencia < UMBRAL_ALTO)
                return "ALTO";
            if (supervivencia < UMBRAL_MEDIO)
                return "MEDIO";
            return "";
        }
    }
}
