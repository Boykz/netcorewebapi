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
    public interface IRegionsService : IBaseService<RegionsModel>
    {
    }
    public class RegionsService : IRegionsService
    {
        RegionsModel modelType = null;
        public DapperService db { get; set; }

        public RegionsService(DapperService db)
        {
            this.db = db;
        }
        public RegionsModel Get(int id)
        {
            RegionsModel ret = db.QueryFirst(modelType, "SELECT * FROM Regions where Id=@Id", new { Id = id });
            return ret;
        }

        public RegionsModel GetProcedure(int id)
        {
            RegionsModel ret2 = null;
            RegionsModel ret = db.QueryFirst(ret2, "GetRegionFullArea", new { Id = id }, commandType: CommandType.StoredProcedure);
            return ret;
        }
        public IEnumerable<RegionsModel> GetList()
        {
            IEnumerable<RegionsModel> items = db.Query<RegionsModel>("SELECT * FROM Regions");
            return items;
        }

        public bool Save(RegionsModel model)
        {
            string query = "INSERT INTO Regions(Name,ParentId) VALUES(@Name,@ParentId)";
            int affectedRows = db.Execute(query, model);

            return affectedRows > 0;
        }

        public bool Update(RegionsModel model, int Id)
        {
            string query = "UPDATE Regions SET Name=@Name,ParentId=@ParentId,Status=@Status WHERE Id=@Id";
            int affectedRows = db.Execute(query, model);
            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Regions WHERE Id=@Id";
            int affectedRows = db.Execute(query, new { Id = id });
            return affectedRows > 0;
        }

        public static string GetRegionFullAreaName(DapperService db,int id)
        {
            RegionsModel ret2 = null;
            string ret = db.QueryFirst(ret2, "GetRegionFullAreaName", new { Id = id }, commandType: CommandType.StoredProcedure)?.Name.Trim();
            return ret;
        }
        public static IEnumerable<RegionsModel> GetFull(DapperService db,int id)
        {
            IEnumerable<RegionsModel> ret = db.Query<RegionsModel>("GetRegionFullAreaName", new { Id = id }, commandType: CommandType.StoredProcedure);
            return ret;
        }
        public static bool checkForExists(DapperService db,int id)
        {
            RegionsModel ret = null;
            ret = db.QueryFirst(ret, "SELECT * FROM Regions where Id=@Id", new { Id = id });
            return ret != null;
        }
    }
}
