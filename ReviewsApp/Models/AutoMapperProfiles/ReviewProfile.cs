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
                                Id = r.TagViewModel.Tag1Id,
                                Text = (r.TagViewModel.Tag1 ?? "").ToLower(),
                                Count = GetTagCount(r.TagViewModel.Tag1Id)
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag2Id,
                                Text = (r.TagViewModel.Tag2 ?? "").ToLower(),
                                Count = GetTagCount(r.TagViewModel.Tag2Id)
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag3Id,
                                Text = (r.TagViewModel.Tag3 ?? "").ToLower(),
                                Count = GetTagCount(r.TagViewModel.Tag3Id)
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag4Id,
                                Text = (r.TagViewModel.Tag4 ?? "").ToLower(),
                                Count = GetTagCount(r.TagViewModel.Tag4Id)
                            },
                            new()
                            {
                                Id = r.TagViewModel.Tag5Id,
                                Text = (r.TagViewModel.Tag5 ?? "").ToLower(),
                                Count = GetTagCount(r.TagViewModel.Tag5Id)
                            }
                        }))
                .ReverseMap();
        }

        private int GetTagCount(int id)
        {
            bool isExistingTag = id < 1;
            const int firstTagId = 1;
            return isExistingTag ? firstTagId : id;
        }
    }
}
