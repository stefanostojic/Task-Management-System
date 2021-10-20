using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task_Management_System.Auth
{
    public class TMSJwtTokens
    {
        public const string Issuer = "TMS";
        public const string Audience = "Users";
        public const string Key = "1234567890123456";

        public const string AuthSchemes = "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
