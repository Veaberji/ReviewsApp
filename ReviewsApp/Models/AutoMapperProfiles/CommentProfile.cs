using AutoMapper;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<CreateCommentViewModel, Comment>()
                .ForMember(d => d.PublishingDate,
                    o => o.MapFrom(c => DateTime.UtcNow));

            CreateMap<Comment, CommentViewModel>()
                .ForMember(d => d.Author,
                    o => o.MapFrom(c => c.Author));
        }
    }
}
