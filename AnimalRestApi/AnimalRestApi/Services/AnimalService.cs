using AnimalRestApi.Models;
using AnimalRestApi.Repositories;

namespace AnimalRestApi.Services;

public class AnimalService(IAnimalRepository repository) : IAnimalService
{
    public IEnumerable<Animal> GetAnimals()
    {
        return repository.GetAnimals();
    }
}