namespace Ucu.Poo.GameOfLife;

using System.IO;

public static class Tablero
{
    // Carga el tablero desde un archivo de texto y lo convierte en una matriz bidimensional de booleanos
    public static bool[,] CargarTablero(string rutaArchivo)
    {
        string[] lineasContenido = File.ReadAllLines(rutaArchivo); // Lee todas las líneas del archivo
        int ancho = lineasContenido[0].Length; // Determina el ancho del tablero basado en la longitud de la primera línea
        int altura = lineasContenido.Length; // Determina la altura del tablero basado en el número de líneas
        bool[,] tablero = new bool[ancho, altura]; // Crea una matriz para almacenar el tablero

        // Recorre cada línea del archivo para poblar la matriz tablero
        for (int y = 0; y < altura; y++)
        {
            for (int x = 0; x < ancho; x++)
            {
                tablero[x, y] = lineasContenido[y][x] == '1'; // Asigna verdadero si el carácter es '1' (celda viva), de lo contrario, falso (celda muerta)
            }
        }

        return tablero; // Retorna el tablero cargado
    }
}
