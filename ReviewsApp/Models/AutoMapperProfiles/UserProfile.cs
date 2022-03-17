using AutoMapper;
using ReviewsApp.Models.Common;
using ReviewsApp.ViewModels.Account;
using ReviewsApp.ViewModels.Admin;
using ReviewsApp.ViewModels.MainReview.Components;
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

            CreateMap<User, UserProfileViewModel>();

            CreateMap<User, UserViewModel>();

            CreateMap<User, AuthorViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(u => u.DisplayName))
                .ForMember(d => d.LikesForAuthor,
                    o => o.MapFrom(u => MapLikes(u)));
        }

        private int MapLikes(User author)
        {
            var result = 0;
            var reviews = author.Reviews;
            foreach (var likes in reviews.Select(r => r.Likes))
            {
                var count = likes.Count;
                result += count;
            }

            return result;
            //return author.Reviews.Select(r => r.Likes).Sum(likes => likes.Count);
        }
    }
}
