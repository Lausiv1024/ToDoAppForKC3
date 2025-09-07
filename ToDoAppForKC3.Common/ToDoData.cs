namespace ToDoAppForKC3.Common;

public class ToDoData
{
    public required int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required bool IsCompleted { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? CompletedAt { get; set; }
    public DateTime? Deadline { get; set; }
}
