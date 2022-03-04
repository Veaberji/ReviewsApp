using AutoMapper;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview;
using System;
using System.Collections.Generic;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewViewModel, MainReview.Review>()
                .ForMember(d => d.DateAdded,
                    o => o.MapFrom(r => DateTime.UtcNow))
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
                                Id = r.TagViewModel.Tag1Id,
                                Text = (r.TagViewModel.Tag1 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag2Id,
                                Text = (r.TagViewModel.Tag2 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag3Id,
                                Text = (r.TagViewModel.Tag3 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag4Id,
                                Text = (r.TagViewModel.Tag4 ?? "").ToLower(),
                                Count = 1
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag5Id,
                                Text = (r.TagViewModel.Tag5 ?? "").ToLower(),
                                Count = 1
                            }
                        }));
        }
    }
}
