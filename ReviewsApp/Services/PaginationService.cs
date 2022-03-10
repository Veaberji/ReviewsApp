using ReviewsApp.Models.Settings;
using ReviewsApp.ViewModels.MainReview.Components;
using System;

namespace ReviewsApp.Services
{
    public class PaginationService
    {
        private readonly int _maxLinksAmount = AppConfigs.PaginationLinksAmount;
        private int _pagesAmount;
        private int _pageIndex;
        private const int MinFirstPageIndex = 1;

        public PaginationViewModel CreatePagination(int pageIndex,
            int amountReviews, string actionMethod)
        {
            _pagesAmount = GetPagesAmount(amountReviews);
            _pageIndex = pageIndex;
            return new PaginationViewModel
            {
                PageIndex = pageIndex,
                FirstPageIndex = GetFirstPageIndex(),
                LastPageIndex = GetLastPageIndex(),
                PreviousPage = GetPreviousPage(),
                NextPage = GetNextPage(),
                ActionMethod = actionMethod
            };
        }

        private int GetPreviousPage()
        {
            return _pageIndex > 1 ? _pageIndex - 1 : _pageIndex;
        }

        private int GetNextPage()
        {
            return _pageIndex == _pagesAmount ? _pageIndex : _pageIndex + 1;
        }

        private int GetFirstPageIndex()
        {
            int possibleLinksAfter = _maxLinksAmount / 2;
            int calculatedFirstPageIndex = _pageIndex - possibleLinksAfter;
            int linksAfterCurrent = Math.Min(_pagesAmount - _pageIndex, possibleLinksAfter);
            int maxLinksBeforeCurrent = _maxLinksAmount - linksAfterCurrent - 1;
            int firstPageIndex = Math.Max(calculatedFirstPageIndex, MinFirstPageIndex);
            int possibleFirstPageIndex = Math
                .Max(_pageIndex - maxLinksBeforeCurrent, MinFirstPageIndex);
            return Math.Min(firstPageIndex, possibleFirstPageIndex);
        }

        private int GetLastPageIndex()
        {
            int possibleLinksBefore = _maxLinksAmount / 2;
            int linksBeforeCurrent = Math.Min(_pageIndex - MinFirstPageIndex, possibleLinksBefore);
            int maxLinksAfterCurrent = _maxLinksAmount - linksBeforeCurrent - 1;
            int calculatedLastPageIndex = _pageIndex + maxLinksAfterCurrent;
            int lastPageIndex = Math.Min(calculatedLastPageIndex, _pagesAmount);
            int possibleLastPageIndex = Math
                .Min(_pageIndex + maxLinksAfterCurrent, _pagesAmount);
            return Math.Max(lastPageIndex, possibleLastPageIndex);
        }

        private int GetPagesAmount(int amountReviews)
        {
            return (int)Math.Ceiling(amountReviews /
                (double)AppConfigs.ReviewsPageSize - 1) + 1;
        }
    }
}
