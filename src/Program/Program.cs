using System.Threading; // proporciona clases y métodos para trabajar con subprocesos (threads) y operaciones relacionadas con la sincronización.

namespace Ucu.Poo.GameOfLife;
public class GameOfLife
{
    public static void Main()
    {
        bool[,] tableroInicial = Lector.CargarTablero("board.txt"); // Carga el tablero desde un archivo
        Logica logica = new Logica(tableroInicial); // Inicializa la lógica del juego
        ImprimirTablero imprimirTablero = new ImprimirTablero(logica); // Crea una instancia para imprimir el tablero

        Thread hiloImpresion = new Thread(imprimirTablero.Imprimir); // Inicia un hilo para la impresión
        hiloImpresion.Start();

        while (true)
        {
            logica.AvanzarGeneracion(); // Calcula la próxima generación
            Thread.Sleep(300); // Pausa entre generaciones
        }
    }
}

