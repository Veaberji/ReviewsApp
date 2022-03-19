using AutoMapper;
using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using ReviewsApp.ViewModels.MainReview.Components;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Services
{
    public class TagsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TagsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void UpdateTags(Review updatedReview, IList<Tag> tags)
        {
            DeleteTagsFromReview(updatedReview, tags);
            AddNewTagsAsync(updatedReview, tags);
        }

        public void SetTags(Review review)
        {
            review.Tags = GetTagsWithCounts(review.Tags);
        }

        private void DeleteTagsFromReview(Review updatedReview, IList<Tag> editedTags)
        {
            var editedTagsTexts = editedTags.Select(tag => tag.Text).ToList();
            var tagsToDelete = updatedReview.Tags
                .Where(tag => !editedTagsTexts.Contains(tag.Text)).ToList();

            UpdateReviewTags(updatedReview, tagsToDelete);
            DeleteTags(tagsToDelete);
        }

        public void DeleteTags(List<Tag> tagsToDelete)
        {
            foreach (var tag in tagsToDelete)
            {
                if (tag.Count > 1)
                {
                    tag.Count--;
                }
                else
                {
                    _unitOfWork.Tags.Remove(tag);
                }
            }
        }

        public List<TagAutoCompeteViewModel> GetSameTags(string prefix)
        {
            var tags = _unitOfWork.Tags.GetTagsStartWith(prefix);
            return tags.Select(tag =>
                _mapper.Map<TagAutoCompeteViewModel>(tag)).ToList();
        }

        private static void UpdateReviewTags(Review updatedReview, List<Tag> tagsToDelete)
        {
            foreach (var tag in tagsToDelete)
            {
                updatedReview.Tags.Remove(tag);
            }
        }

        private void AddNewTagsAsync(Review updatedReview, IList<Tag> tags)
        {
            var existingTags = updatedReview.Tags.Select(t => t.Text);
            var newTags = tags.Where(t => !existingTags.Contains(t.Text)).ToList();
            var updatedNewTags = GetTagsWithCounts(newTags);
            updatedReview.Tags.AddRange(updatedNewTags);

        }

        private List<Tag> GetTagsWithCounts(IList<Tag> tags)
        {
            var tempTags = new List<Tag>();
            foreach (var tag in tags)
            {
                if (IsAdded(tempTags, tag))
                {
                    continue;
                }
                var tagInDb = _unitOfWork.Tags
                    .Find(t => t.Text == tag.Text).FirstOrDefault();
                var isExistingTag = tagInDb is not null;
                if (isExistingTag)
                {
                    tagInDb.Count++;
                    tempTags.Add(tagInDb);
                }
                else
                {
                    tag.Count++;
                    tempTags.Add(tag);
                }
            }
            return tempTags;
        }

        private static bool IsAdded(List<Tag> tempTags, Tag tag)
        {
            return tempTags.Any(tempTag => tempTag.Text == tag.Text);
        }
    }
}
