using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.MainReview;
using System.Collections.Generic;
using System.Linq;

namespace ReviewsApp.Services
{
    public class TagsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void UpdateTags(Review updatedReview, IList<Tag> tags)
        {
            DeleteTagsFromReview(updatedReview, tags);
            AddNewTagsAsync(updatedReview, tags);
        }

        public void ChangeTags(Review review)
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
            foreach (var tag in updatedNewTags)
            {
                updatedReview.Tags.Add(tag);
            }
        }

        private List<Tag> GetTagsWithCounts(IList<Tag> tags)
        {
            var tempTags = new List<Tag>();
            foreach (var tag in tags)
            {
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
    }
}
