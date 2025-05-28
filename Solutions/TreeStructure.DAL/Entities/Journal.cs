namespace TreeStructure.DAL.Entities;

public class Journal
{
    public long Id { get; set; }
    public Guid EventId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string Text { get; set; }
    public string Parameters { get; set; }
    public string StackTrace { get; set; }
}