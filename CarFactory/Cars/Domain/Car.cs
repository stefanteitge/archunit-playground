namespace CarFactory.Cars.Domain;

public class Car(Engine engine)
{
    public Engine Engine { get; } = engine;
}