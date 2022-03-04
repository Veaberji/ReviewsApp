using AutoMapper;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CommentViewModel, Comment>()
                .ForMember(d => d.PublishingDate,
                    o => o.MapFrom(r => DateTime.UtcNow));
        }
    }
}
