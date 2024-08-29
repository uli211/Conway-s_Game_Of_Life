namespace Ucu.Poo.GameOfLife
{
    using System;
    using System.Text;      //incluye clases para manejar y manipular textos, como StringBuilder.
    using System.Threading; // proporciona clases y métodos para trabajar con subprocesos (threads) y operaciones relacionadas con la sincronización.

    public class ImprimirTablero
    {
        private readonly Logica logica; // Lógica del juego

        public ImprimirTablero(Logica logicaJuego)
        {
            logica = logicaJuego; // Recibe la lógica del juego
        }

        public void Imprimir()
        {
            while (true)
            {
                bool[,] tablero = logica.ObtenerTablero(); // Obtiene el estado actual del tablero
                StringBuilder s = new StringBuilder();

                for (int i = 0; i < tablero.GetLength(0); i++)
                {
                    for (int j = 0; j < tablero.GetLength(1); j++)
                    {
                        s.Append(tablero[i, j] ? "|X|" : "___"); // Representa las celdas como 'X' o '_'
                    }

                    s.Append("\n"); // Salto de línea para separar filas del tablero
                }

                Console.Clear(); // Elimina lo que hay en la consola 
                Console.WriteLine(s.ToString()); // Imprime el tablero
                Thread.Sleep(300); // Pausa antes de la próxima impresión
            }
        }
    }
}