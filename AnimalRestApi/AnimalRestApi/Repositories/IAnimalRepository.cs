using AnimalRestApi.Models;

namespace AnimalRestApi.Repositories;

public interface IAnimalRepository
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(AnimalDto animal);
    Animal? GetAnimalById(int id);
}