using System;
using System.Collections.Generic;

namespace MonteCarloLibrary
{
    public static class MonteCarloGenerator
    {
        //Se instancia un objeto de tipo random para posteriormente generar la semilla
        private static Random random = new Random();
        /// <summary>
        /// Genera una cantidad de numeros pseudoaleatorios por Montecarlo.
        /// </summary>
        /// <param name="quantity">Cantidad de numeros a generar</param>
        /// <returns>Un array double de N cantidad de numeros pseudoaleatorios</returns>
        public static double[] MonteCarlo(int quantity)
        {
            //Lista en donde se almacenan los números generador
            List<double> generated_nums = new List<double>();
            //Generación de la semilla
            int seed = (int)(random.NextDouble() * 10000);
            Console.WriteLine("Seed: " + seed);
            //Inicialmente el xi es igual a la semilla
            int xi = seed;
            //Bucle que itera n veces segun el parametro quantity
            while (quantity > 0)
            {
                //se obtiene el cuadrado del xi
                int x2i = xi * xi;
                //se obtiene la longitud del xi cuadrado
                int extension = x2i.ToString().Length;
                quantity--;
                //se extraen 4 digitos del xi cuadrado dependiendo su extensión
                int extracted = extractNums(x2i, extension);
                //se añaden el numero generado al arreglo
                generated_nums.Add((double)extracted / 10000);
                //Ahora el xi es igual al numero de 4 digitos extraido anteriormente
                xi = extracted;
            }

            return generated_nums.ToArray();
        }
        /// <summary>
        /// Extrae 4 digitos de un parametro entero
        /// </summary>
        /// <param name="num">Numero del cual se extrae el nuevo numero de 4 digitos</param>
        /// <param name="extension">Longitud del numero dado</param>
        /// <returns>Un numero de longitud 4</returns>
        private static int extractNums(int num, int extension)
        {
            int segmento = 0;
            //conversion del numero a String para cortarlo posteriormente
            string num_str = num.ToString();
            //Calculo de la posicion en la que iniciará el cortado
            int inicio = (extension - 4) / 2;
            //Calculo de la posicion en la que finalizará el cortado
            int fin = inicio + 4;
            //Si el número es como mínimo de longitud 4 entonces es útil
            if (num_str.Length >= 4)
            {
                segmento = int.Parse(num_str.Substring(inicio, 4));
            }
            return segmento;
        }
    }
}
