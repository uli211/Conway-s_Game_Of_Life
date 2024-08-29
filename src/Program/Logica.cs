namespace Ucu.Poo.GameOfLife;

public class Logica
{
    private bool[,] tablero;
    private int filas;
    private int columnas;

    public Logica(bool[,] tableroInicial)
    {
        tablero = tableroInicial;
        filas = tablero.GetLength(0);       // Obtiene el número de filas del tablero
        columnas = tablero.GetLength(1);    // Obtiene el número de columnas del tablero
    }


    public void AvanzarGeneracion()  // Método que avanza a la siguiente generación del juego
    {
        bool[,] nuevoTablero = new bool[filas, columnas];

        for (int i = 0; i < filas; i++)
        {
            for (int j = 0; j < columnas; j++)
            {
                int vecinosVivos = ContarVecinosVivos(i, j);

                // Aplica las reglas del juego
                if (tablero[i, j]) 
                    nuevoTablero[i, j] = (vecinosVivos == 2 || vecinosVivos == 3); 
                else 
                    nuevoTablero[i, j] = (vecinosVivos == 3); 
            }
        }

        tablero = nuevoTablero;
    }

    // Cuenta los vecinos vivos alrededor de una celda
    private int ContarVecinosVivos(int x, int y)
    {
        int vecinosVivos = 0;
        for (int i = x - 1; i <= x + 1; i++)
        {
            for (int j = y - 1; j <= y + 1; j++)
            {
                int xEnvuelto = (i + filas) % filas;
                int yEnvuelto = (j + columnas) % columnas;
                if ((xEnvuelto != x || yEnvuelto != y) && tablero[xEnvuelto, yEnvuelto])
                {
                    vecinosVivos++;
                }
            }
        }
        return vecinosVivos;
    }

    public bool[,] ObtenerTablero() => tablero;
}
