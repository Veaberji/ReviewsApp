using Azure;
using Azure.Search.Documents;
using Azure.Search.Documents.Models;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class SearchService
    {
        private readonly AzureKeyCredential _credential;
        private readonly Uri _endpoint;
        private readonly IUnitOfWork _unitOfWork;

        public SearchService(IUnitOfWork unitOfWork, string queryKey)
        {
            _unitOfWork = unitOfWork;
            _credential = new AzureKeyCredential(queryKey);
            _endpoint = new Uri(SearchConfigs.EndpointUrl);
        }

        public async Task<IEnumerable<ReviewSearchResultViewModel>> GetResults(string data)
        {
            var models = new List<ReviewSearchResultViewModel>();
            await SearchInReviews(data, models);
            await SearchInComments(data, models);

            return models;
        }

        private async Task SearchInReviews(string data,
            List<ReviewSearchResultViewModel> models)
        {
            var searchReviewsClient = GetSearchClient(SearchConfigs.ReviewsIndex);
            var reviewOptions = GetOptions(
                $"{SearchConfigs.TitleNameInReviewsIndex}," +
                $"{SearchConfigs.BodyNameInReviewsIndex}");
            var reviewsResults = (await searchReviewsClient
                    .SearchAsync<ReviewSearchResultViewModel>(data, reviewOptions))
                .Value.GetResults();
            AddResultsToModels(models, reviewsResults);
        }


        private SearchClient GetSearchClient(string indexName)
        {
            return new SearchClient(_endpoint, indexName, _credential);
        }

        private SearchOptions GetOptions(string highlightedFields)
        {
            return new SearchOptions
            {
                HighlightFields = { highlightedFields },
                HighlightPreTag = SearchConfigs.PreTag,
                HighlightPostTag = SearchConfigs.PostTag,
            };
        }

        private static void AddResultsToModels(
            List<ReviewSearchResultViewModel> models,
            IEnumerable<SearchResult<ReviewSearchResultViewModel>> reviewsResults)
        {
            models.AddRange(reviewsResults.Select(InitReviewModel));
        }

        private static ReviewSearchResultViewModel InitReviewModel(
            SearchResult<ReviewSearchResultViewModel> result)
        {
            string title = GetTitle(result);
            return CreateModelFromReviewResult(result, title);
        }

        private static string GetTitle(SearchResult<ReviewSearchResultViewModel> result)
        {
            var (key, value) = result.Highlights.First();
            return key == $"{SearchConfigs.TitleNameInReviewsIndex}"
                ? string.Join(" ", value)
                : result.Document.Title;
        }

        private static ReviewSearchResultViewModel CreateModelFromReviewResult(
            SearchResult<ReviewSearchResultViewModel> result,
            string title)
        {
            var model = GetResultViewModel(result.Document.Id, title);
            foreach (var values in result.Highlights.Values)
            {
                if (HasText(model))
                {
                    AppendSpace(model);
                }
                model.HighlightedText += string.Join(" ", values);
            }

            return model;
        }

        private static bool HasText(ReviewSearchResultViewModel model)
        {
            return model.HighlightedText?.Length > 0;
        }

        private static void AppendSpace(ReviewSearchResultViewModel model)
        {
            model.HighlightedText += " ";
        }

        private static ReviewSearchResultViewModel GetResultViewModel(
            string id, string title)
        {
            var model = new ReviewSearchResultViewModel
            {
                Id = id,
                Title = title
            };
            return model;
        }

        private async Task SearchInComments(string data,
            List<ReviewSearchResultViewModel> models)
        {
            var searchCommentsClient = GetSearchClient(SearchConfigs.CommentsIndex);
            var commentsOptions = GetOptions(SearchConfigs.BodyNameInCommentsIndex);
            var commentsResults = (await searchCommentsClient
                    .SearchAsync<CommentSearchResultViewModel>(data, commentsOptions))
                .Value.GetResults();
            await AddFoundCommentsToReviews(models, commentsResults);
        }

        private async Task AddFoundCommentsToReviews(
            List<ReviewSearchResultViewModel> models,
            Pageable<SearchResult<CommentSearchResultViewModel>> commentsResults)
        {
            foreach (var result in commentsResults)
            {
                int reviewId = result.Document.ReviewId;
                var model = models.FirstOrDefault(m => m.Id == reviewId.ToString());
                if (model is not null)
                {
                    AddCommentsToModelText(result, model);
                }
                else
                {
                    model = await CreateModelFromCommentResult(reviewId, result);
                    models.Add(model);
                }
            }
        }

        private static void AddCommentsToModelText(
            SearchResult<CommentSearchResultViewModel> result,
            ReviewSearchResultViewModel model)
        {
            foreach (var values in result.Highlights.Values)
            {
                if (HasText(model))
                {
                    AppendSpace(model);
                }
                model.HighlightedText += string.Join(" ", values);
            }
        }

        private async Task<ReviewSearchResultViewModel> CreateModelFromCommentResult(
            int reviewId, SearchResult<CommentSearchResultViewModel> result)
        {
            var review =
                await _unitOfWork.Reviews.GetByIdAsync(reviewId);
            var model = GetResultViewModel(reviewId.ToString(), review.Title);
            AddCommentsToModelText(result, model);

            return model;
        }
    }
}
