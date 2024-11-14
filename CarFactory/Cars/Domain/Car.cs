using CarFactory.Employees.Domain;

namespace CarFactory.Cars.Domain;

public class Car(string name, Engine engine, Employee usuallyBuiltBy)
{
    public string Name { get; } = name;
    
    public Engine Engine { get; } = engine;
    
    public Employee UsuallyBuiltBy { get; } = usuallyBuiltBy;
}