namespace CarFactory.Cars.Domain;

public class Car(string name, Engine engine)
{
    public string Name { get; } = name;
    
    public Engine Engine { get; } = engine;
}