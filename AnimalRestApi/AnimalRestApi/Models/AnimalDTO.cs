using System.ComponentModel.DataAnnotations;

namespace AnimalRestApi.Models;

public record AnimalDto(string Name, string Description, string Category, string Area)
{}