using Intv.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Services
{
   
   public interface IBaseService<T>
    {
        DapperService db { get; set; }
        T Get(int id);
        IEnumerable<T> GetList();
        bool Save(T model);
        bool Update(T model, int Id);
        bool Delete(int id);
    }
}
