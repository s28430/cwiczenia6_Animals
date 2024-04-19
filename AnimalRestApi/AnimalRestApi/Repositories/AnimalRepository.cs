using System.Data.SqlClient;
using AnimalRestApi.Models;

namespace AnimalRestApi.Repositories;

public class AnimalRepository(IConfiguration configuration) : IAnimalRepository
{
    public IEnumerable<Animal> GetAnimals()
    {
        using var conn = new SqlConnection(configuration["conn-string"]);
        conn.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT a.idAnimal, a.name, a.description, a.category, a.area " +
                          "FROM Animal a";

        var animals = new List<Animal>();

        var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var animal = new Animal(
                id:(int)dr["idanimal"],
                name:dr["name"].ToString(),
                description:dr["description"].ToString() ?? "",
                category:dr["category"].ToString(),
                area:dr["area"].ToString()
            );
            
            animals.Add(animal);
        }
        return animals;
    }
}