using AnimalRestApi.Models;

namespace AnimalRestApi.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals();
}