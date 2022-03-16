using AutoMapper;
using ReviewsApp.Models.Common;
using ReviewsApp.ViewModels.Account;

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
        }
    }
}
