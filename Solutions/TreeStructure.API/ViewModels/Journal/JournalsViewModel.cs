namespace TreeStructure.API.ViewModels.Journal;

public class JournalsViewModel
{
    public int Skip { get; set; }
    public int Count { get; set; }
    public List<JournalInfoViewModel> Items { get; set; }
}