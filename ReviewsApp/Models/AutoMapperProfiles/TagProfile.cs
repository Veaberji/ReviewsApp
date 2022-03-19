using AutoMapper;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.Home;
using ReviewsApp.ViewModels.MainReview.Components;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class TagProfile : Profile
    {
        public TagProfile()
        {
            CreateMap<Tag, TagCloudViewModel>()
                .ForMember(d => d.Text,
                    o => o.MapFrom(t => t.Text))
                .ForMember(d => d.CssClass,
                    o => o.MapFrom(t => GetTagCssClass(t.Count)));

            CreateMap<Tag, TagAutoCompeteViewModel>()
                .ForMember(d => d.Val,
                    o => o.MapFrom(t => t.Id))
                .ForMember(d => d.Label,
                    o => o.MapFrom(t => t.Text));
        }

        private static string GetTagCssClass(int count)
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
