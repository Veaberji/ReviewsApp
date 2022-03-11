﻿using AutoMapper;
using Markdig;
using ReviewsApp.Models.MainReview;
using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels.Home;
using ReviewsApp.ViewModels.MainReview;
using ReviewsApp.ViewModels.MainReview.SingleReview;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Models.AutoMapperProfiles
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<CreateReviewViewModel, Review>()
                .ForMember(d => d.DateAdded,
                    o => o.MapFrom(r => DateTime.UtcNow))
                .ForMember(d => d.Product,
                    o => o.MapFrom(r => new Product
                    {
                        Name = r.ProductViewModel.Name,
                        Type = r.ProductViewModel.Type
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

            CreateMap<Review, PreviewViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(r => r.Author.DisplayName))
                .ForMember(d => d.AverageUserRating,
                    o => o.MapFrom(r => r.Product.GetAverageUserRating()))
                .ForMember(d => d.PreviewImageUrl,
                    o => o.MapFrom(r => r.Images.FirstOrDefault().Url))
                .ForMember(d => d.Tags,
                    o => o.MapFrom(r => r.Tags.Select(t => t.Text)))
                .ForMember(d => d.ProductViewModel,
                    o => o.MapFrom(r => r.Product))
                .ForMember(d => d.TotalRates,
                    o => o.MapFrom(r => r.Product.Grades.Count))
                .ForMember(d => d.Body,
                    o => o.MapFrom(r => FormatPreviewBody(r.Body)));

            CreateMap<Review, ReviewViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(r => r.Author.DisplayName))
                .ForMember(d => d.AverageUserRating,
                    o => o.MapFrom(r => r.Product.GetAverageUserRating()))
                .ForMember(d => d.PreviewImageUrl,
                    o => o.MapFrom(r => r.Images.FirstOrDefault().Url))
                .ForMember(d => d.Tags,
                    o => o.MapFrom(r => r.Tags.Select(t => t.Text)))
                .ForMember(d => d.ProductViewModel,
                    o => o.MapFrom(r => r.Product))
                .ForMember(d => d.TotalRates,
                    o => o.MapFrom(r => r.Product.Grades.Count))
                .ForMember(d => d.ImagesUrls,
                    o => o.MapFrom(r => r.Images.Select(i => i.Url)))
                .ForMember(d => d.TotalLikes,
                    o => o.MapFrom(r => r.Likes.Count))
                .ForMember(d => d.Body,
                    o => o.MapFrom(r => ConvertMarkdownToHtml(r.Body)));

            CreateMap<Review, StarRatingViewModel>()
                .ForMember(d => d.ProductName,
                    o => o.MapFrom(r => r.Product.Name));

            CreateMap<Review, GradeResponseViewModel>()
                .ForMember(d => d.Rating,
                    o => o.MapFrom(r => r.Product.GetAverageUserRating()))
                .ForMember(d => d.TotalRates,
                    o => o.MapFrom(r => r.Product.Grades.Count));

            CreateMap<Review, TopRatedReviewViewModel>()
                .ForMember(d => d.AuthorName,
                    o => o.MapFrom(r => r.Author.DisplayName))
                .ForMember(d => d.AverageUserRating,
                    o => o.MapFrom(r => r.Product.GetAverageUserRating()))
                .ForMember(d => d.ProductName,
                    o => o.MapFrom(r => r.Product.Name))
                .ForMember(d => d.ProductType,
                    o => o.MapFrom(r => r.Product.Type));
        }
        private string FormatPreviewBody(string text)
        {
            if (text.Length <= AppConfigs.PreviewBodySize)
            {
                return ConvertMarkdownToHtml(text);
            }

            var cutText = GetCutText(text);
            return ConvertMarkdownToHtml(cutText);
        }

        private string GetCutText(string text)
        {
            var cutText = text[..AppConfigs.PreviewBodySize];
            var lastValidChar = cutText.LastOrDefault(char.IsLetterOrDigit);
            var textLastSpaceIndex = cutText.LastIndexOf(lastValidChar);
            if (textLastSpaceIndex == -1)
            {
                return cutText;
            }
            var textCutByLastValidChar = cutText[..textLastSpaceIndex];
            var lastSpaceIndex = textCutByLastValidChar.LastIndexOf(' ');
            return lastSpaceIndex == -1 ? textCutByLastValidChar + "..." :
                textCutByLastValidChar[..lastSpaceIndex] + "...";
        }

        private string ConvertMarkdownToHtml(string text)
        {
            var pipeline = new MarkdownPipelineBuilder().UseAdvancedExtensions().Build();
            return Markdown.ToHtml(text, pipeline);
        }
    }
}
