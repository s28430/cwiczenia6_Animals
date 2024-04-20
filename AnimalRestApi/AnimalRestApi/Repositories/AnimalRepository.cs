using System.Data.SqlClient;
using AnimalRestApi.Models;

namespace AnimalRestApi.Repositories;

public class AnimalRepository(IConfiguration configuration) : IAnimalRepository
{

    public IEnumerable<Animal> GetAnimals(string orderBy)
    {
        using var conn = new SqlConnection(configuration["conn-string"]);
        conn.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT a.idAnimal, a.name, a.description, a.category, a.area " +
                          "FROM Animal a " +
                          "ORDER BY " + orderBy;

        var animals = new List<Animal>();

        var dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            var animal = new Animal(
                id:(int)dr["idanimal"],
                name:dr["name"].ToString() ?? "",
                description:dr["description"].ToString() ?? "",
                category:dr["category"].ToString() ?? "",
                area:dr["area"].ToString() ?? ""
            );
            
            animals.Add(animal);
        }
        return animals;
    }

    public int AddAnimal(AnimalDto animal)
    {
        using var conn = new SqlConnection(configuration["conn-string"]);
        conn.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "INSERT INTO animal(name, description, category, area) " +
                          "VAlUES(@name, @description, @category, @area)";
        cmd.Parameters.AddWithValue("name", animal.Name);
        cmd.Parameters.AddWithValue("description", animal.Description);
        cmd.Parameters.AddWithValue("category", animal.Category);
        cmd.Parameters.AddWithValue("area", animal.Area);

        var affected = cmd.ExecuteNonQuery();
        return affected;
    }

    public Animal? GetAnimalById(int id)
    {
        using var conn = new SqlConnection(configuration["conn-string"]);
        conn.Open();

        using var cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = "SELECT a.idAnimal, a.name, a.description, a.category, a.area " +
                          "FROM animal a " +
                          "WHERE a.idAnimal = @id";
        cmd.Parameters.AddWithValue("id", id);
        var dr = cmd.ExecuteReader();

        if (!dr.Read())
        {
            return null;
        }

        var animal = new Animal(
            id: (int)dr["idAnimal"],
            name: dr["name"].ToString() ?? "",
            description:dr["description"].ToString() ?? "",
            category: dr["category"].ToString() ?? "",
            area: dr["area"].ToString() ?? ""
        );
        return animal;
    }
}