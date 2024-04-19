using AnimalRestApi.Models;

namespace AnimalRestApi.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
}