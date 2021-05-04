using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "поля login не может быть пустым")]
        public string login { get; set; }

        [Required(ErrorMessage = "поля password не может быть пустым")]
        public string password { get; set; }
    }
}
