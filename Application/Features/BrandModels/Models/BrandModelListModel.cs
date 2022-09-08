using Application.Features.BrandModels.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.BrandModels.Models
{
    public class BrandModelListModel : BasePageableModel
    {
        public IList<BrandModelListDto> Items { get; set; }
    }
}
