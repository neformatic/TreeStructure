using AutoMapper;
using TreeStructure.API.ViewModels.Tree;
using TreeStructure.BLL.Models.Tree;

namespace TreeStructure.API.Mapping;

public class TreeMapping : Profile
{
    public TreeMapping()
    {
        CreateMap<TreeNodeViewModel, TreeNodeModel>().ReverseMap();
    }
}