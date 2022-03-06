using ReviewsApp.Models.Settings;
using ReviewsApp.Models.Settings.Constrains;
using System;

namespace ReviewsApp.Services
{
    public class PaginationService
    {
        public int GetPagesAmount(int amountReviews)
        {
            var dbPagesAmount = (int)Math.Ceiling(amountReviews /
                (double)ReviewConstrains.ReviewsPageSize - 1) + 1;

            var size = Math.Min(AppConfigs.PaginationLinksAmount, dbPagesAmount);
            return size;
        }

        public int GetPreviousPage(int pageIndex)
        {
            return pageIndex > 1 ? pageIndex - 1 : pageIndex;
        }

        public int GetNextPage(int pageIndex, int pagesAmount)
        {
            return pageIndex == pagesAmount ? pageIndex : pageIndex + 1;
        }
    }
}
