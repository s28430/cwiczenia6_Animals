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
                                        $" It should be one of the following: {string.Join(", ", ValidOrderByValues)}");
        }
        return repository.GetAnimals(orderBy);
    }
}