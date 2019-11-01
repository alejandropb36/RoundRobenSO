using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoundRobinSO
{
    public class Competencia
    {
        public class Partido
        {
            public int local = -1;
            public int visitante = -1;
        }

        private Partido[,] calcularLigaNumEquiposPar(int numEquipos)
        {
            int numRondas = numEquipos - 1;
            int numPartidosPorRonda = numEquipos / 2;

            Partido[,] rondas = new Partido[numRondas, numPartidosPorRonda];

            for (int i = 0, k = 0; i < numRondas; i++)
            {
                for (int j = 0; j < numPartidosPorRonda; j++)
                {
                    rondas[i, j] = new Partido();

                    rondas[i, j].local = k;

                    k++;

                    if (k == numRondas)
                        k = 0;
                }
            }

            for (int i = 0; i < numRondas; i++)
            {
                if (i % 2 == 0)
                {
                    rondas[i, 0].visitante = numEquipos - 1;
                }
                else
                {
                    rondas[i, 0].visitante = rondas[i, 0].local;
                    rondas[i, 0].local = numEquipos - 1;
                }
            }

            int equipoMasAlto = numEquipos - 1;
            int equipoImparMasAlto = equipoMasAlto - 1;

            for (int i = 0, k = equipoImparMasAlto; i < numRondas; i++)
            {
                for (int j = 1; j < numPartidosPorRonda; j++)
                {
                    rondas[i, j].visitante = k;

                    k--;

                    if (k == -1)
                        k = equipoImparMasAlto;
                }
            }

            return rondas;
        }

        private Partido[,] calcularLigaNumEquiposImpar(int numEquipos)
        {
            int numRondas = numEquipos;
            int numPartidosPorRonda = numEquipos / 2;

            Partido[,] rondas = new Partido[numRondas, numPartidosPorRonda];

            for (int i = 0, k = 0; i < numRondas; i++)
            {
                for (int j = -1; j < numPartidosPorRonda; j++)
                {
                    if (j >= 0)
                    {
                        rondas[i, j] = new Partido();

                        rondas[i, j].local = k;
                    }

                    k++;

                    if (k == numRondas)
                        k = 0;
                }
            }

            int equipoMasAlto = numEquipos - 1;

            for (int i = 0, k = equipoMasAlto; i < numRondas; i++)
            {
                for (int j = 0; j < numPartidosPorRonda; j++)
                {
                    rondas[i, j].visitante = k;

                    k--;

                    if (k == -1)
                        k = equipoMasAlto;
                }
            }

            return rondas;
        }

        public Partido[,] calcularLiga(int numEquipos)
        {
            if (numEquipos % 2 == 0)
                return calcularLigaNumEquiposPar(numEquipos);
            else
                return calcularLigaNumEquiposImpar(numEquipos);
        }

        public void mostrarPartidos(Partido[,] rondas, ref TextBox textBoxContent)
        {
            textBoxContent.Text = "Competencia de equipos" + Environment.NewLine;
            Console.WriteLine("IDA");

            for (int i = 0; i < rondas.GetLength(0); i++)
            {
                Console.Write("Ronda " + (i + 1) + ": ");
                textBoxContent.Text += "Ronda " + (i + 1) + ": ";

                for (int j = 0; j < rondas.GetLength(1); j++)
                {
                    textBoxContent.Text += "   " + (1 + rondas[i, j].local) + "-" + (1 + rondas[i, j].visitante);
                    Console.Write("   " + (1 + rondas[i, j].local) + "-" + (1 + rondas[i, j].visitante));
                }

                Console.WriteLine();
                textBoxContent.Text += Environment.NewLine;
            }
        }
    }
}
