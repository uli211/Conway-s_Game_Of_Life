namespace Ucu.Poo.GameOfLife
{

    using System.Threading;
    

// Clase principal del programa
    public class GameOfLive
    {
        public static void Main()
        {
            // Cargar el tablero desde el archivo "board.txt" usando el método CargarTablero de la clase TableroDeJuego
            bool[,] tableroInicial = Tablero.CargarTablero("board.txt");

            // Crear una instancia de la lógica del juego con el tablero cargado
            Logica logicaJuego = new Logica(tableroInicial);

            // Crear una instancia de la clase que se encarga de mostrar el tablero en consola
            MostrarTablero mostrarTablero = new MostrarTablero(logicaJuego);

            // Crear e iniciar un hilo para ejecutar el método ImprimirTablero de MostrarTablero
            Thread hiloImpresion = new Thread(ImprimirTablero.MostrarTablero);
            hiloImpresion.Start(); // Iniciar el hilo que imprimirá el tablero

            // Bucle infinito que representa el ciclo de vida del juego
            while (true)
            {
                // Avanzar a la siguiente generación de células en el tablero
                logicaJuego.AvanzarGeneracion();

                // Pausar la ejecución durante 300 ms antes de avanzar a la siguiente generación
                Thread.Sleep(300);
            }
        }
    }
}