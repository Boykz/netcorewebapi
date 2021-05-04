using Dapper;
using Intv.Helpers;
using Intv.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Intv.Services
{
    public interface IItemsService : IBaseService<ItemsModel>
    {       
    }

    public class ItemsService : IItemsService
    {
        ItemsModel modelType = null;
        public DapperService db { get; set; }
        public ItemsService(DapperService db)
        {
            this.db = db;
        }
       public ItemsModel Get(int id)
        {
            ItemsModel ret =  db.QueryFirst(modelType, "SELECT * FROM Items where Id = @Id;", new { Id = id });
            return ret;
        }
        public IEnumerable<ItemsModel> GetList()
        {
            IEnumerable<ItemsModel> items = db.Query<ItemsModel>("SELECT * FROM Items");
            return items;
        }

        public bool Save(ItemsModel model)
        {
            string query = "INSERT INTO Items(Name,Description,Price,Count) VALUES(@Name,@Description,@Price,@Count)";
            int affectedRows = db.Execute(query, model);

            return affectedRows > 0;
        }

        public bool Update(ItemsModel model, int Id)
        {
            string query = "UPDATE Items SET Name=@Name,Description=@Description,Price=@Price,Count=@Count,Status=@Status WHERE Id=@Id";
            int affectedRows = db.Execute(query, model);
            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Items WHERE Id=@Id";
            int affectedRows = db.Execute(query, new { Id = id});
            return affectedRows > 0;
        }

        public static List<ItemsModel> getValidItemsList(DapperService db, IEnumerable<int> Ids)
        {
            List<ItemsModel> items = new List<ItemsModel>();
            items = (List<ItemsModel>)db.Query<ItemsModel>("SELECT * FROM Items where Id in ("+String.Join(",",Ids)+")");
            return items;
        }
    }
}
