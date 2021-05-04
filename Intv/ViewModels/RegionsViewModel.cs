using Intv.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.ViewModels
{
    public class RegionsViewModel
    {
        [Required(ErrorMessage = "поля Name не может быть пустым")]
        public string Name { get; set; }

        [CheckStatus(ErrorMessage = "введите допустипый значение для поля Status")]
        public int Status { get; set; }

        [Required(ErrorMessage = "поля ParentId не может быть пустым")]
        public int ParentId { get; set; }
    }
}
