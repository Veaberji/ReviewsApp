using AutoMapper;
using ReviewsApp.ViewModels;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagCloudViewModel>()
                .ForMember(d => d.Text,
                    o => o.MapFrom(r => r.Text))
                .ForMember(d => d.CssClass,
                    o => o.MapFrom(r => GetTagCssClass(r.Count)));

            CreateMap<Tag, TagAutoCompeteViewModel>()
                .ForMember(d => d.Val,
                    o => o.MapFrom(r => r.Id))
                .ForMember(d => d.Label,
                    o => o.MapFrom(r => r.Text));
        }

        private string GetTagCssClass(int count)
        {
            string cssClass;
            if (count <= 1)
                cssClass = "tagSize1";
            else if (count <= 3)
                cssClass = "tagSize2";
            else if (count <= 5)
                cssClass = "tagSize3";
            else if (count <= 8)
                cssClass = "tagSize4";
            else cssClass = "tagSize5";
            return cssClass;
        }
    }
}
