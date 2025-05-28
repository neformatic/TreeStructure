namespace TreeStructure.BLL.Models.Journal;

public class JournalsModel
{
    public int Skip { get; set; }
    public int Count { get; set; }
    public List<JournalInfoModel> Items { get; set; }
}