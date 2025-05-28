using AutoMapper;
using TreeStructure.API.ViewModels.Node;
using TreeStructure.BLL.Models.Node;

namespace TreeStructure.API.Mapping;

public class NodeMapping : Profile
{
    public NodeMapping()
    {
        CreateMap<CreateNodeViewModel, CreateNodeModel>().ReverseMap();
        CreateMap<UpdateNodeViewModel, UpdateNodeModel>().ReverseMap();
    }
}