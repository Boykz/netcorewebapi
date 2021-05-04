using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.ViewModels
{
    public class OrdersViewModel
    {
        public int RegionId { get; set; }
        public IEnumerable<int> Items { get; set; }
    }
}
