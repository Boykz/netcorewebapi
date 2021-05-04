using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intv.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "testapp"; 
        public const string AUDIENCE = "testapp_client"; 
        const string KEY = "aSsfd%$#34jbEsa56#C#2348";  
        public const int LIFETIME = 10; 
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
