using System.Collections.Generic;

namespace Task_Management_System.DTO
{
    public class PagedResponse<TModel>
    {
        const int MaxPageSize = 500;
        private int _pageSize;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public IEnumerable<TModel> Items { get; set; }

        public PagedResponse()
        {
            Items = new List<TModel>();
        }
    }
}
