using AutoMapper;
using ReviewsApp.ViewModels;
using System;
using System.Collections.Generic;

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
                .ForMember(d => d.Tags,
                    o => o.MapFrom(r =>
                        new List<Tag>
                    {
                            new()
                            {
                                Text = (r.TagViewModel.Tag1 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Text = (r.TagViewModel.Tag2 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Text = (r.TagViewModel.Tag3 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Text = (r.TagViewModel.Tag4 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Text = (r.TagViewModel.Tag5 ?? "").ToLower(),
                                Count = 1
                            }
                        }))
                .ReverseMap();
        }
    }
}
