using ReviewsApp.ViewModels.MainReview.Components;
using System;

namespace ReviewsApp.ViewModels.MainReview.SingleReview;

public class CommentViewModel
{
    public string Body { get; set; }
    public AuthorViewModel Author { get; set; }
    public DateTime PublishingDate { get; set; }
}