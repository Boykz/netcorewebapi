using Intv.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intv.Helpers
{
    public class Validation
    {
        public static object getValidationErrors<T>(T model)
        {
            List<Validation> ret = new List<Validation>();
            var results = new List<ValidationResult>();
            var context = new ValidationContext(model);
            if (!Validator.TryValidateObject(model, context, results, true))
            {

                return new { Errors = results.Select(x => x.ErrorMessage) };
            }
            return new { Errors = results };

        }
    }
    public class CheckPriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                if (Decimal.TryParse(value.ToString(), out decimal res))
                {
                    if (res > 0 || res != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
    public class CheckStatusAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                int res;
                int.TryParse(value.ToString(), out res);
                if (Enum.IsDefined(typeof(Statuses), res))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
