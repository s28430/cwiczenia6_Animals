using System.ComponentModel.DataAnnotations;

namespace AnimalRestApi.Models;

public class Animal(int id, string name, string description, string category, string area)
{
    [Key]
    public int Id { get; } = id;

    [Required] [MaxLength(50)] public string Name { get; set; } = name;
    
    [MaxLength(200)] public string Description { get; set; } = description;

    [Required] public string Category { get; set; } = category;

    [Required] [MaxLength(200)] public string Area { get; set; } = area;

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