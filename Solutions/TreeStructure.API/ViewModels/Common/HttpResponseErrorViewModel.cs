using TreeStructure.Common.Enums;

namespace TreeStructure.API.ViewModels.Common;

public class HttpResponseErrorViewModel
{
    public string ErrorMessage { get; set; }
    public BadRequestMessageLevel ErrorMessageLevel { get; set; }
}