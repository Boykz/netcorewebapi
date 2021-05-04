using Intv.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Intv.Models
{
    public class UsersModel : BaseModel
    {
        public string Login { get; private set; }
        private string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public int Role { get; set; }

        public static UsersModel GetAuthUser(DapperService db,string login, string pass)
        {
            UsersModel user = null;
            string hashPassword = MD5HAshing.Hash(pass);
            user = db.QueryFirst<UsersModel>(user,"select * from users where Login = @login and Password = @pass",new { login,pass=hashPassword });
            return user;
        }
    }

    public static class MD5HAshing
    {
        private static string GetMd5Hash(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
        public static string Hash(string data)
        {
            using (var md5 = MD5.Create())
                return GetMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }
    }
}
