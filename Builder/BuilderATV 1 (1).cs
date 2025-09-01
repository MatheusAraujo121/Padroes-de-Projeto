enum Transmission 
{
    MANUAL,
    AUTOMATIC,
    AUTOMATIC_SEQUENTIAL
}

enum VehicleType
{
    SEDAN,
    SPORTCAR,
    PICKUPTRUCK,
    TRUCK,
    SUV
}

class Engine
{
    private double power;
    public double Power { 
        get => power; 
        set => power = value; 
        }
    public Engine(double power) { 
        this.Power = power; 
        }
}

interface IBuilder
{
    void Reset();
    Vehicle GetVehicle();
    void SetSeats(int seats);
    void SetEngine(Engine engine);
    void SetTransmission(Transmission transmission);
    void SetVehicleType(VehicleType vehicleType);
}

class Vehicle
{
    public int Seats { get; set; }
    public Engine Engine { get; set; }
    public Transmission Transmission { get; set; }
    public VehicleType VehicleType { get; set; }
    public bool Airbag { get; set; } // Diferencial para o SUV
}

class CarBuilder : IBuilder
{
    private Vehicle vehicle;

    public CarBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        vehicle = new Vehicle();
    }

    public void SetSeats(int seats)
    {
        vehicle.Seats = seats;
    }

    public void SetEngine(Engine engine)
    {
        vehicle.Engine = engine;
    }

    public void SetTransmission(Transmission transmission)
    {
        vehicle.Transmission = transmission;
    }

    public void SetVehicleType(VehicleType vehicleType)
    {
        vehicle.VehicleType = vehicleType;
    }
    
    public void SetAirbag(bool airbag)
    {
        vehicle.Airbag = airbag;
    }

    public Vehicle GetVehicle()
    {
        return vehicle;
    }
}

class Director
{
    public void ConstructSedanCar(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(4);
        builder.SetEngine(new Engine(1.6));
        builder.SetTransmission(Transmission.AUTOMATIC);
        builder.SetVehicleType(VehicleType.SEDAN);
    }

    public void ConstructTruck(IBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(2);
        builder.SetEngine(new Engine(5.0));
        builder.SetTransmission(Transmission.MANUAL);
        builder.SetVehicleType(VehicleType.TRUCK);
    }

    public void ConstructSUV(CarBuilder builder)
    {
        builder.Reset();
        builder.SetSeats(5);
        builder.SetEngine(new Engine(2.6));
        builder.SetTransmission(Transmission.AUTOMATIC_SEQUENTIAL);
        builder.SetVehicleType(VehicleType.SUV);
        builder.SetAirbag(true);
    }
}

class Program
{
    static void Main()
    {
        Director director = new Director();
        CarBuilder builder = new CarBuilder();

        director.ConstructSedanCar(builder);
        Vehicle sedan = builder.GetVehicle();
        Console.WriteLine("Sedan criado: " + sedan.VehicleType + ", Motor: " + sedan.Engine.Power + "L" + ", Câmbio: " + sedan.Transmission.ToString());

        director.ConstructTruck(builder);
        Vehicle truck = builder.GetVehicle();
        Console.WriteLine("Caminhão criado: " + truck.VehicleType + ", Motor: " + truck.Engine.Power + "L" + ", Câmbio: " + truck.Transmission.ToString());

        director.ConstructSUV(builder);
        Vehicle suv = builder.GetVehicle();
        Console.WriteLine("SUV criado: " + suv.VehicleType + ", Motor: " + suv.Engine.Power + "L " + ", Câmbio: " + suv.Transmission.ToString() + ", Airbag: " + suv.Airbag);
    }
}
