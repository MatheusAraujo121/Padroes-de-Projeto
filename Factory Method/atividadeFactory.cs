using System;

// Interface do Produto
public interface IVehicle
{
    void StartRoute();
    void GetCargo();
}

// Classe Concreta do Produto: Carro
public class Carro : IVehicle
{
    public void StartRoute()
    {
        Console.WriteLine("Iniciando uma rota de carro.");
    }

    public void GetCargo()
    {
        Console.WriteLine("Carregando a carga.");
    }
}

// Classe Concreta do Produto: bicicleta
public class Bicicleta : IVehicle
{
    public void StartRoute()
    {
        Console.WriteLine("Iniciando uma rota de bicicleta.");
    }

    public void GetCargo()
    {
        Console.WriteLine("Não está com carga.");
    }
}

// Classe Abstrata da Fábrica
public abstract class Transport
{
    public void StartTransport()
    {
        IVehicle vehicle = CreateTransport();
        vehicle.StartRoute();
    }
    public abstract IVehicle CreateTransport();
}

// Classe Concreta da Fábrica: CarroFactory
public class CarroFactory : Transport
{
    public override IVehicle CreateTransport()
    {
        return new Carro();
    }
}

// Classe Concreta da Fábrica: bicicletaFactory
public class bicicletaFactory : Transport
{
    public override IVehicle CreateTransport()
    {
        return new Bicicleta();
    }
}

// Classe Cliente
public class Cliente
{
    private readonly IVehicle _Vehicle;

    public Cliente(Transport factory)
    {
        _Vehicle = factory.CreateTransport();
    }

    public void StartVehicleRoute()
    {
        _Vehicle.StartRoute();
    }
}

// Programa Principal
class Program
{
    static void Main(string[] args)
    {
        Transport carroFactory = new CarroFactory();
        Cliente clienteCarro = new Cliente(carroFactory);
        clienteCarro.StartVehicleRoute(); // Saída: Dirigindo um carro.

        Transport bicicletaFactory = new bicicletaFactory();
        Cliente clientebicicleta = new Cliente(bicicletaFactory);
        clientebicicleta.StartVehicleRoute(); // Saída: Dirigindo uma bicicleta.
    }
}
