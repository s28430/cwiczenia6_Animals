using System.ComponentModel.DataAnnotations;
using Cwiczenia5.Models;

namespace AnimalRestApi.Models;

public class Animal
{
    private static int _nextId = 1;
    public int Id { get; }

    [Required] [MaxLength(50)] public string Name { get; set; }

    [Required] public AnimalType AnimalType { get; set; }

    [Required] [Range(1, 50)] public double Weight { get; set; }

    [Required] [MaxLength(50)] public string SkinColor { get; set; }

    public Animal(string name, AnimalType animalType, double weight, string skinColor)
    {
        Id = _nextId;
        _nextId++;

        Name = name;
        AnimalType = animalType;
        Weight = weight;
        SkinColor = skinColor;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;
        if (this == obj) return true;
        if (GetType() != obj.GetType()) return false;

        var another = (Animal)obj;

        return Id == another.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}