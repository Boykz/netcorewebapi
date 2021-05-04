using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
