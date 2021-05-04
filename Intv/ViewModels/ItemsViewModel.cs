using Intv.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.ViewModels
{
    public class ItemsViewModel
    {
        [Required(ErrorMessage = "поля Name не может быть пустым")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required(ErrorMessage = "поля Price не может быть пустым")]
        [CheckPrice(ErrorMessage = "поля Price не может быть меньше или равно нулью")]
        public decimal Price { get; set; }
        public int Count { get; set; }

        [CheckStatus(ErrorMessage = "введите допустипый значение для поля Status")]
        public int Status { get; set; }
    }
}
