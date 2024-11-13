using CarFactory.Cars.Domain;
using CarFactory.Core;

namespace CarFactory.Cars.Persistence;

public interface ICarRepository : IRepository
{
    Car? GetCarById(Guid carId);
}