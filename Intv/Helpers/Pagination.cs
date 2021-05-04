using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Helpers
{
    public class Pagination
    {
        public static int ItemsForPage = 5;
        public int CurrentPage { get; set; }
        public int ItemsCount { get; set; }
        public int TotalPages { get; private set; }
        

        public bool HasPreviousPage
        {
            get
            {
                return (CurrentPage > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (CurrentPage < TotalPages);
            }
        }
        public Pagination(int itemsCount, int currentPage)
        {
            TotalPages = (int)Math.Ceiling(itemsCount / (double)ItemsForPage);
            ItemsCount = itemsCount;
            CurrentPage = currentPage;
        }
    }
}
