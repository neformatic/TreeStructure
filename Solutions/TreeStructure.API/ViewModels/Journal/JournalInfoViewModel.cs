namespace TreeStructure.API.ViewModels.Journal;

public class JournalInfoViewModel
{
    public long Id { get; set; }
    public Guid EventId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}