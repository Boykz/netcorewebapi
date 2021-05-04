using Intv.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Models
{

    public class ItemsModel : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }

        public ItemsModel()
        {

        }
        public ItemsModel(ItemsViewModel model)
        {
            Name = model.Name;
            Description = model.Description;
            Price = model.Price;
            Count = model.Count;
            Status = model.Status;
        }
    }
}
