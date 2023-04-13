static void Main(string[] args)
    {
        // Crear drones repartidores
        IRepartidorCreator droneCreator = new DroneCreator();
        IRepartidor drone = droneCreator.CrearRepartidor();


        drone.EntregarPedido();


        // Crear repartidor humano
        IRepartidorCreator repartidorHumanoCreator = new RepartidorHumanoCreator();
        IRepartidor repartidorHumano = repartidorHumanoCreator.CrearRepartidor();

        repartidorHumano.EntregarPedido();
    }

public interface IRepartidor
{
    void EntregarPedido();
}


public class Drone : IRepartidor
{
    public void EntregarPedido()
    {
        Console.WriteLine("Entregando pedido con Drone");
    }
}

public class RepartidorHumano : IRepartidor
{
    public void EntregarPedido()
    {
        Console.WriteLine("Entregando pedido con Repartidor Humano");
    }
}


public interface IRepartidorCreator
{
    IRepartidor CrearRepartidor();
}


public class DroneCreator : IRepartidorCreator
{
    public IRepartidor CrearRepartidor()
    {
        return new Drone();
    }
}


public class RepartidorHumanoCreator : IRepartidorCreator
{
    public IRepartidor CrearRepartidor()
    {
        return new RepartidorHumano();
    }
}


