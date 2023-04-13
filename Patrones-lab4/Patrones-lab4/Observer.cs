static void Main(string[] args)
{
    var pedido = new Pedido();
    var cliente = new Cliente();

    pedido.AgregarObservador(cliente);

    pedido.CambiarEstado("En preparación");
    pedido.CambiarEstado("Enviado");
    pedido.CambiarEstado("Entregado");
}

public class Pedido
{
    private List<IObserver> observadores = new List<IObserver>();

    public string Estado { get; private set; }

    public void CambiarEstado(string nuevoEstado)
    {
        Estado = nuevoEstado;
        NotificarObservadores();
    }

    public void AgregarObservador(IObserver observador)
    {
        observadores.Add(observador);
    }

    public void EliminarObservador(IObserver observador)
    {
        observadores.Remove(observador);
    }

    private void NotificarObservadores()
    {
        foreach (var observador in observadores)
        {
            observador.Actualizar(this);
        }
    }
}

public interface IObserver
{
    void Actualizar(Pedido pedido);
}

public class Cliente : IObserver
{
    public void Actualizar(Pedido pedido)
    {
        Console.WriteLine($"El pedido está en estado {pedido.Estado}");
    }
}

