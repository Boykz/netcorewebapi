using Intv.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Models
{
    public class OrdersModel : BaseModel
    {
        public int UserId { get; set; }
        public UsersModel User { get; set; }
        public int RegionId { get; set; }
        public RegionsModel Region { get; set; }

        public IEnumerable<int> ItemsIds { get; set; }
        public List<ItemsModel> Items { get; set; }
        public decimal Sum { get; set; }
        public DateTime CreatedTime { get; set; }
        public OrdersModel()
        {
            User = new UsersModel();
            Region = new RegionsModel();
            Items = new List<ItemsModel>();
        }
        public OrdersModel(ViewModels.OrdersViewModel model)
        {
            RegionId = model.RegionId;
            ItemsIds = model.Items;

        }
    }
}
