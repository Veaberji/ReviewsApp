namespace ReviewsApp.ViewModels.MainReview.Components
{
    public class PaginationViewModel
    {
        public int PageIndex { get; set; }
        public int PagesAmount { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
        public string ActionMethod { get; set; }
    }
}
