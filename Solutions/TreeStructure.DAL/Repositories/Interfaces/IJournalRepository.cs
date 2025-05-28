using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Repositories.Interfaces;

public interface IJournalRepository
{
    Task CreateAsync(Journal journal);
    Task<Journal> GetSingleAsync(long id);
    IQueryable<Journal> GetJournalsAsQueryable();
}