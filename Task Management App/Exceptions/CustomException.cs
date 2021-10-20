using System;

namespace Task_Management_System.Exceptions
{
    public class CustomException : Exception
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public CustomException()
        {
            StatusCode = 500;
            ErrorMessage = "Internal server error.";
        }
    }
}
