using Microsoft.EntityFrameworkCore;
using TreeStructure.DAL.Entities;
using TreeStructure.DAL.Repositories.Interfaces;

namespace TreeStructure.DAL.Repositories;

public class JournalRepository : IJournalRepository
{
    private readonly TreeStructureDbContext _dbContext;

    public JournalRepository(TreeStructureDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateAsync(Journal journal)
    {
        await _dbContext.Journals.AddAsync(journal);
    }

    public async Task<Journal> GetSingleAsync(long id)
    {
        var journal = await _dbContext.Journals
            .Where(j => j.Id == id)
            .Select(j => new Journal
            {
                Id = j.Id,
                EventId = j.EventId,
                CreatedAt = j.CreatedAt,
                Text = j.Text
            })
            .FirstOrDefaultAsync();

        return journal;
    }

    public IQueryable<Journal> GetJournalsAsQueryable()
    {
        return _dbContext.Journals.AsNoTracking();
    }
}