using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Auth
{
    public class TokenReponse
    {
        public string Token { get; set; }
        public DateTime ValidTo { get; set; }

        public TokenReponse(string token, DateTime validTo)
        {
            Token = token;
            ValidTo = validTo;
        }
    }
}
