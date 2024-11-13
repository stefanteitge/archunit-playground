using CarFactory.Cars.Dto;
using CarFactory.Cars.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace CarFactory.Cars.Controllers;

public class CarController(ICarRepository carRepository) : ControllerBase
{
    public CarDto? GetCar(Guid carId)
    {
        return null;
    }
}