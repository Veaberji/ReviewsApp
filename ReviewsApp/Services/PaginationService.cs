using ReviewsApp.Models.Interfaces;
using ReviewsApp.Models.Settings;
using ReviewsApp.Models.Settings.Constrains;
using System;
using System.Threading.Tasks;

namespace ReviewsApp.Services
{
    public class PaginationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PaginationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetPagesAmount()
        {
            var dbPagesAmount = (int)Math.Ceiling(
                await _unitOfWork.Reviews.GetReviewsAmountAsync() /
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
