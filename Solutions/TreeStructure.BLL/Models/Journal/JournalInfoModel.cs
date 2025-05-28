namespace TreeStructure.BLL.Models.Journal;

public class JournalInfoModel
{
    public long Id { get; set; }
    public Guid EventId { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
}