using AutoMapper;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(d => d.Name,
                    o => o.MapFrom(r => r.Name))
                .ForMember(d => d.Type,
                    o => o.MapFrom(r => r.Type));
        }
    }
}
