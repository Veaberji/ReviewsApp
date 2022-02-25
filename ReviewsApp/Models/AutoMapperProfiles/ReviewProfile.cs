using AutoMapper;
using ReviewsApp.ViewModels;
using System;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<ReviewViewModel, Review>()
                .ForMember(d => d.DateAdded,
                    o => o.MapFrom(r => DateTime.Now))
                .ForMember(d => d.Product,
                    o => o.MapFrom(r => new Product
                    {
                        Name = r.ProductViewModel.ProductName,
                        Type = r.ProductViewModel.ProductType
                    }))
                .ReverseMap();
        }
    }
}
