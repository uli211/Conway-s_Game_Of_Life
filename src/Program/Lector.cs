namespace Ucu.Poo.GameOfLife;

using System.IO;    //contiene clases para trabajar con entradas y salidas de datos, como archivos y flujos de datos (streams).
public class Lector
{
    public static bool[,] CargarTablero(string rutaArchivo)
    {
        // Lee todas las líneas del archivo
        string[] lineas = File.ReadAllLines(rutaArchivo);
        int filas = lineas.Length;
        int columnas = lineas[0].Length;
        bool[,] tablero = new bool[filas, columnas];

        // Rellena el tablero con "1" (vivo) o "0" (muerto)
        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                tablero[i, j] = lineas[i][j] == '1';
            }
        }
        return tablero;
    }
}
