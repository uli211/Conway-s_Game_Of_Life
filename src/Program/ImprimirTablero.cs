using System;
using System.Text;
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    public class ImprimirTablero
    {
        private readonly Logica logicaJuego; // Referencia a la lógica del juego para obtener el tablero actual

        private static readonly object
            objetoBloqueo = new object(); // Objeto para sincronización de hilos al imprimir en consola

        // Constructor que inicializa la clase con la lógica del juego
        public ImprimirTablero(Logica logica)
        {
            logicaJuego = logica; // Asigna la lógica del juego al campo logicaJuego
        }

        // Método que imprime continuamente el tablero en la consola
        public void MostrarTablero()
        {
            int anchoConsola = Console.WindowWidth; // Obtiene el ancho actual de la consola
            while (true) // Bucle infinito para actualizar e imprimir el tablero
            {
                lock (objetoBloqueo) // Asegura que solo un hilo pueda acceder a este bloque a la vez
                {
                    Console.Clear(); // Limpia la consola antes de imprimir el tablero
                    bool[,] tablero = logicaJuego.ObtenerTablero(); // Obtiene el estado actual del tablero
                    int ancho = tablero.GetLength(0); // Obtiene el ancho del tablero
                    int altura = tablero.GetLength(1); // Obtiene la altura del tablero
                    StringBuilder
                        s = new StringBuilder(); // Crea un objeto StringBuilder para construir la salida de texto

                    // Determina el ancho del tablero a mostrar, limitándolo al ancho de la consola
                    int anchoTablero = Math.Min(ancho, anchoConsola);

                    // Recorre cada celda del tablero para construir la representación en texto
                    for (int y = 0; y < altura; y++)
                    {
                        for (int x = 0; x < anchoTablero; x++)
                        {
                            s.Append(tablero[x, y]
                                ? "|X|"
                                : "___"); // Añade "|X|" para celdas vivas y "___" para celdas muertas
                        }

                        s.Append("\n"); // Añade una nueva línea después de cada fila
                    }

                    Console.WriteLine(s.ToString()); // Imprime la representación del tablero en la consola
                }

                Thread.Sleep(300); // Espera 300 ms antes de la próxima actualización
            }
        }
    }
}   
