using AnimalRestApi.Models;
using AnimalRestApi.Repositories;

namespace AnimalRestApi.Services;

public class AnimalService(IAnimalRepository repository) : IAnimalService
{
    private static readonly List<string> ValidOrderByValues = ["name", "description", "category", "area"];
    private bool IsOrderByValid(string orderBy)
    {
        return !string.IsNullOrEmpty(orderBy) && ValidOrderByValues.Contains(orderBy);
    }
    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        if (!IsOrderByValid(orderBy))
        {
            throw new ArgumentException($"Invalid value for orderBy." +
                                        $" It should be one of the following: {string.Join(", ", ValidOrderByValues)}.");
        }
        return repository.GetAnimals(orderBy);
    }

    public int AddAnimal(AnimalDto animal)
    {
        return repository.AddAnimal(animal);
    }

    public Animal GetAnimalById(int id)
    {
        var animal = repository.GetAnimalById(id);
        if (animal is null)
        {
            throw new ArgumentException($"The animal with id {id} was not found.");
        }

        return animal;
    }

    public void UpdateAnimal(int id, AnimalDto animalDto)
    {
        var affected = repository.UpdateAnimal(id, animalDto);
        if (affected == 0)
        {
            throw new ArgumentException($"The animal with id {id} was not found");
        }
    }
}