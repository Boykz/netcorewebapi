using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Helpers
{
    public class Roles
    {
        public const int CUSTOMER = 2;

        public const int ADMINISTRATOR = 4;

        public static string getRoleName(int value)
        {
            switch (value)
            {
                case Roles.CUSTOMER:
                    return "Customer";
                case Roles.ADMINISTRATOR:
                    return "Administrator";
                default:
                    break;
            }
            return null;
        }
    }
}
