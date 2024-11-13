using CarFactory.Cars.Commands;

namespace CarFactory.Cars.Handler;

public class CreateCarHandler
{
    public void Handle(CreateCarCommand command)
    {
        Console.WriteLine($"Create car {command.Name}");
    }
}