using System;

namespace ReviewsApp.ViewModels.MainReview.SingleReview;

public class CommentViewModel
{
    public string Body { get; set; }
    public string AuthorName { get; set; }
    public DateTime PublishingDate { get; set; }
}