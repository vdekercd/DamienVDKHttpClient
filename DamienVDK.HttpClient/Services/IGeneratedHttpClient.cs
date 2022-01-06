namespace DamienVDKHttpClient.Services;

public interface IGeneratedHttpClient
{
    [Post("/V1/Todo")]
    Task PostTodoAsync(Todo todo);

    [Get("/V1/Todo")]
    Task<List<Todo>> GetTodoAsync();
}
