using AutoMapper;
using TreeStructure.API.ViewModels.Journal;
using TreeStructure.API.ViewModels.Journal.Filter;
using TreeStructure.BLL.Models.Journal;
using TreeStructure.BLL.Models.Journal.Filter;
using TreeStructure.Common.Models;

namespace TreeStructure.API.Mapping;

public class JournalMapping : Profile
{
    public JournalMapping()
    {
        CreateMap<JournalViewModel, JournalModel>().ReverseMap();
        CreateMap<JournalInfoViewModel, JournalInfoModel>().ReverseMap();
        CreateMap<PaginationResultModel<JournalInfoViewModel>, PaginationResultModel<JournalInfoModel>>().ReverseMap();
        CreateMap<JournalsFilterViewModel, JournalsFilterModel>().ReverseMap();
    }
}