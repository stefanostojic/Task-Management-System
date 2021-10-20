using Task_Management_System.Exceptions;

namespace Task_Management_System.DTO
{
    public class PaginationFilter
    {
        private int _pageSize;
        private int _pageNumber;

        public PaginationFilter()
        {
            PageNumber = 1;
            PageSize = 3;
        }

        public PaginationFilter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public int PageNumber 
        {
            get
            {
                return _pageNumber;
            }
            set
            {
                if (value < 1)
                {
                    throw new CustomException() { ErrorMessage = "Page number can't be less than 1." };
                }
                _pageNumber = value;
            }
        }

        public int PageSize 
        {
            get
            {
                return _pageSize;
            }
            set 
            {
                if (value < 1)
                {
                    throw new CustomException() { ErrorMessage = "Page size can't be less than 1." };
                }
                _pageSize = value;
            } 
        }
    }
}
