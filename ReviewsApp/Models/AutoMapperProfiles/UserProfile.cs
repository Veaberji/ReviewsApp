using AutoMapper;
using ReviewsApp.Models.Common;
using ReviewsApp.ViewModels.Account;
using ReviewsApp.ViewModels.Admin;
using ReviewsApp.ViewModels.MainReview.Components;
using ReviewsApp.ViewModels.Profile;
using System.Linq;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterViewModel, User>()
                .ForMember(d => d.UserName,
                    o => o.MapFrom(r => r.Login));

            CreateMap<User, ProfileViewModel>();

            CreateMap<User, UserViewModel>();

            CreateMap<User, AuthorViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(u => u.DisplayName))
                .ForMember(d => d.LikesForAuthor,
                    o => o.MapFrom(u => MapLikes(u)));
        }

        private static int MapLikes(User author)
        {
            var reviews = author.Reviews;

            return reviews.Select(r => r.Likes).Sum(likes => likes.Count);
        }
    }
}
