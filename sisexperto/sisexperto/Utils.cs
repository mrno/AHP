namespace probaAHP
{
    public class Utils
    {
        public void Productoria(double[,] salida, double[,] entrada)
        {
            int cantidad = entrada.GetLength(1);
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad; j++)
                {
                    salida[i, j] *= entrada[i, j];
                }
            }
        }

        public void Unar(double[,] salida, int cantidad)
        {
            for (int j = 0; j < cantidad; j++)
            {
                for (int k = 0; k < cantidad; k++)
                {
                    salida[j, k] = 1;
                }
            }
        }

        public void Cerar(double[,] salida, int cantidad)
        {
            for (int j = 0; j < cantidad; j++)
            {
                for (int k = 0; k < cantidad; k++)
                {
                    salida[j, k] = 0;
                }
            }
        }
    }
}