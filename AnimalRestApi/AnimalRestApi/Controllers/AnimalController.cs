using AnimalRestApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace AnimalRestApi.Controllers;

[ApiController]
[Route("api/animals")]
public class AnimalController(IAnimalService service) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAnimals(string orderBy = "idAnimal")
    {
        return Ok(service.GetAnimals(orderBy));
    }
}