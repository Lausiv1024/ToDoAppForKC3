using ToDoAppForKC3.Common;

using Microsoft.AspNetCore.Mvc;

namespace ToDoAppForKC3.ApiService.Controller;

[Route("api/[controller]")]
[ApiController]
public class ToDoListController : ControllerBase
{
    List<ToDoData> todoLists;
    public ToDoListController()
    {
        todoLists = [
            new ToDoData { Id = 1, Title = "寝る", Description = "しっかり寝ましょう。7時間睡眠", IsCompleted = false, CreatedAt = DateTime.Now },
            new ToDoData { Id = 2, Title = "勉強会資料作成", Description = "資料を作成します。", IsCompleted = false, CreatedAt = DateTime.Now }
            ];
    }

    [HttpGet("todolists")]
    public async Task<ToDoData[]> GetAllToDoLists()
    {
        return [.. todoLists];
    }

    [HttpGet]
    public async Task<ToDoData> GetToDoListById(int id)
    {
        return todoLists.First(d => d.Id == id);
    }

    [HttpPost("status")]
    public async Task<IActionResult> SetStatus(int id, bool isComplete)
    {
        Console.WriteLine("Id: {0}", id);
        var todo = todoLists.First(d => d.Id == id);
        if (todo is null)
        {
            return NotFound();
        }
        todo.IsCompleted = isComplete;
        todo.CompletedAt = DateTime.Now;
        Console.WriteLine("Changed ToDo : {0}   Status : {1}", todo.Title, todo.IsCompleted);
        return Ok();
    }

    [HttpPost]
    public async Task<IActionResult> AddToDo(ToDoData data)
    {
        Console.WriteLine("Todo Added");
        todoLists.Add(data);
        return Ok();
    }
}
