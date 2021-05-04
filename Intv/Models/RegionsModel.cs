using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Models
{
    public class RegionsModel : BaseModel
    {
        public string Name { get; set; }
        public int ParentId { get; set; }
        public RegionsModel()
        {

        }
        public RegionsModel(ViewModels.RegionsViewModel model)
        {
            Name = model.Name;
            Status = model.Status;
            ParentId = model.ParentId;
        }
    }
}
