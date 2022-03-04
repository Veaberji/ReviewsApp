using AutoMapper;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class ImageProfile : Profile
    {
        public ImageProfile()
        {
            CreateMap<string, Image>()
                .ForMember(d => d.Url,
                    o => o.MapFrom(r => r.ToString()));
        }
    }
}
