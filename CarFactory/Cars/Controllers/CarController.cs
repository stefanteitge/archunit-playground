using CarFactory.Cars.Dtos;
using CarFactory.Cars.Persistence;
using CarFactory.Cars.Query;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Cars.Controllers;

// GetCarByIdQuery will fix the issue
public class CarController(ICarRepository query) : ControllerBase
{
    public CarDto? GetCar(Guid carId)
    {
        var queried = query.GetCarById(carId);

        if (queried is null)
        {
            // better return a 404
            return null;
        }
        
        return new CarDto(queried.Name);
    }
}