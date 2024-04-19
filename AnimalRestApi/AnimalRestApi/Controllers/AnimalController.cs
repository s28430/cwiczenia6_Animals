using AnimalRestApi.Models;
using AnimalRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRestApi.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController(IAnimalService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "name")
    {
        try
        {
            var animals = service.GetAnimals(orderBy);
            return Ok(animals);
        }
        catch (ArgumentException e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddAnimal(AnimalDto animalDto)
    {
        var affected = service.AddAnimal(animalDto);
        return affected > 0 ? StatusCode(StatusCodes.Status201Created) : NoContent();
    }
}