using AutoMapper;
using ReviewsApp.ViewModels;
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
