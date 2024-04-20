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

    [HttpGet("{id:int}")]
    public IActionResult GetAnimalById(int id)
    {
        try
        {
            var animal = service.GetAnimalById(id);
            return Ok(animal);
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpPost]
    public IActionResult AddAnimal(AnimalDto animalDto)
    {
        var affected = service.AddAnimal(animalDto);
        return affected > 0 ? StatusCode(StatusCodes.Status201Created) : NoContent();
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, AnimalDto animalDto)
    {
        try
        {
            service.UpdateAnimal(id, animalDto);
            return Ok();
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        try
        {
            service.DeleteAnimal(id);
            return NoContent();
        }
        catch (ArgumentException e)
        {
            return NotFound(e.Message);
        }
    }
}