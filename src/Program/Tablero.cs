namespace Ucu.Poo.GameOfLife;
public class Tablero
{
    private bool[,] _estado;

    public Tablero(bool[,] estadoInicial)
    {
        _estado = estadoInicial;    // Asigna el estado inicial al tablero
    }

    public bool[,] ObtenerEstado()
    {
        return _estado;     // Retorna la matriz que representa el estado del tablero
    }

    public void ActualizarEstado(bool[,] nuevoEstado)
    {
        _estado = nuevoEstado;      // Reemplaza el estado actual con el nuevo estado
    }
}

