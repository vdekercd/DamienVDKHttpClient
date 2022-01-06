namespace DamienVDKHttpClient.Models;

public class Todo
{
    [JsonProperty("id")]
    public Guid Id { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("createdDate")]
    public DateTime CreatedDate { get; set; }

    [JsonProperty("isDone")]
    public bool IsDone { get; set; }

    public static Todo GetNewInstance(string description)
    {
        return new Todo
        {
            Id = Guid.NewGuid(),
            Description = description,
            CreatedDate = DateTime.Now,
            IsDone = false
        };
    }
}

