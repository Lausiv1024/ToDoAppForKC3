using ToDoAppForKC3.Common;
namespace ToDoAppForKC3.Web;

public class ToDoAPIClient
{
    private readonly HttpClient _httpClient;
    public ToDoAPIClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<ToDoData[]> GetAllToDoListsAsync(CancellationToken cancellationToken = default)
    {
        List<ToDoData>? todoLists = null;
        await foreach (var todo in _httpClient.GetFromJsonAsAsyncEnumerable<ToDoData>("/api/todolist/todolists", cancellationToken))
        {
            if (todo is not null)
            {
                todoLists ??= [];
                todoLists.Add(todo);
            }
        }
        return todoLists?.ToArray() ?? [];
    }
    public async Task<ToDoData?> GetToDoListByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<ToDoData>($"/api/todolist?id={id}", cancellationToken);
    }
    public async Task<bool> MarkAsCompleteAsync(int id, bool isComplete, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsync($"/api/todolist/status?id={id}&isComplete={isComplete}", null, cancellationToken);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> AddToDoAsync(ToDoData data, CancellationToken cancellationToken = default)
    {
        var response = await _httpClient.PostAsJsonAsync("/api/todolist", data, cancellationToken);
        return response.IsSuccessStatusCode;
    }
}
