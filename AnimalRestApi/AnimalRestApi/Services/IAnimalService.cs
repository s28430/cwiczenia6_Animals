using AnimalRestApi.Models;

namespace AnimalRestApi.Services;

public interface IAnimalService
{
    IEnumerable<Animal> GetAnimals(string orderBy);
    int AddAnimal(AnimalDto animal);
    Animal GetAnimalById(int id);
    void UpdateAnimal(int id, AnimalDto animalDto);
    void DeleteAnimal(int id);
}