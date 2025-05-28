using AutoMapper;
using TreeStructure.BLL.Models.Journal;
using TreeStructure.DAL.Entities;

namespace TreeStructure.BLL.Mapping;

public class JournalMapping : Profile
{
    public JournalMapping()
    {
        CreateMap<JournalModel, Journal>().ReverseMap();
    }
}