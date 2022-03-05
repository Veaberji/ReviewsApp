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
                    o => o.MapFrom(r => DateTime.UtcNow));

            CreateMap<Comment, CommentViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(r => r.Author.DisplayName));
        }
    }
}
