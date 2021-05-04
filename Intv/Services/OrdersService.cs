using Intv.Helpers;
using Intv.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Intv.Services
{
    public interface IOrdersService : IBaseService<OrdersModel>
    {
        IEnumerable<OrdersModel> GetList(string itemName, string regionName, int page, ref int itemsCount);
    }
    public class OrdersService : IOrdersService
    {
        OrdersModel modelType = null;
        public DapperService db { get; set; }
        public OrdersService(DapperService db)
        {
            this.db = db;
        }
        public OrdersModel Get(int id)
        {
            OrdersModel ret = null;
            db.ClearParams();
            db.AddParam("@Id", DbType.Int32, id);
            using (IDataReader reader = db.Select(@"select o.*,u.FirstName + ' ' + u.LastName as CustomerName from Orders o 
                                                    left join Users u on u.Id = o.UserId where o.Id = @Id;
                                                   select Id, Name, Description, Price from Items i where i.Id in (select o.ItemId from OrderItems o where o.OrderId = @Id) order by i.Id"))
            {
                while (reader.Read())
                {
                    ret = new OrdersModel();
                    ret.Id = (int)reader["Id"];
                    ret.Status = (int)reader["Status"];
                    ret.Sum = (decimal)reader["Sum"];
                    ret.CreatedTime = (DateTime)reader["CreatedTime"];
                    ret.UserId = ret.User.Id = (int)reader["UserId"];
                    ret.RegionId = ret.Region.Id = (int)reader["RegionId"];
                    ret.Region.Name = RegionsService.GetRegionFullAreaName(db,ret.RegionId);
                    ret.User.FullName = (string)reader["CustomerName"];
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        ret.Items.Add(new ItemsModel{

                        Id = (int)reader["Id"],
                        Name = reader["Name"] as string,
                        Description = reader["Description"] as string,
                        Price = (decimal)reader["Price"],
                    });
                    }
                }

               
            }
            return ret;
        }

        public IEnumerable<OrdersModel> GetList(string itemName, string regionName, int page, ref int itemsCount)
        {
            List<OrdersModel> items = new List<OrdersModel>();
            db.ClearParams();
            db.AddParam("@page", DbType.Int32, page == 1 ? 0 : (page-1) * Pagination.ItemsForPage);
            db.AddParam("@ItemsForPage", DbType.Int32, Pagination.ItemsForPage);
            string query = @" select distinct o.*, u.FirstName + ' ' + u.LastName as CustomerName from Orders o
	left join Users u on u.Id = o.UserId
	inner join Regions r on r.Id = o.RegionId
	inner join OrderItems oi on oi.OrderId = o.Id
	inner join Items i on i.Id = oi.ItemId
where (r.Name LIKE N'%" + regionName + "%' and i.Name LIKE N'%" + itemName + "%') order by o.Id OFFSET  @page  ROWS  FETCH NEXT @ItemsForPage ROWS ONLY; select  count(distinct o.Id) as ItemsCount from Orders o left join Users u on u.Id = o.UserId 	inner join Regions r on r.Id = o.RegionId inner join OrderItems oi on oi.OrderId = o.Id	inner join Items i on i.Id = oi.ItemId where  (r.Name LIKE N'%" + regionName + "%' and i.Name LIKE N'%" + itemName + "%')";
            using (IDataReader reader = db.Select(query))
            {
                while (reader.Read())
                {
                        OrdersModel ret = new OrdersModel();
                        ret.Id = (int)reader["Id"];
                        ret.Status = (int)reader["Status"];
                        ret.Sum = (decimal)reader["Sum"];
                        ret.CreatedTime = (DateTime)reader["CreatedTime"];
                        ret.UserId = ret.User.Id = (int)reader["UserId"];
                        ret.RegionId = ret.User.Id = (int)reader["RegionId"];
                        ret.Region.Name = RegionsService.GetRegionFullAreaName(db,ret.RegionId);
                        ret.User.FullName = (string)reader["CustomerName"];
                    items.Add(ret);
                }
                if (reader.NextResult())
                {
                    while (reader.Read())
                    {
                        itemsCount = (int)reader["ItemsCount"];
                    }
                }
            }
            return items;
        }

        public bool Save(OrdersModel model)
        {
            StringBuilder query = new StringBuilder();
            query.Append("DECLARE @newId TABLE (Id INT) begin transaction insert into Orders(UserId, RegionId, Sum) OUTPUT INSERTED.Id into @newId(Id) values(@UserId, @RegionId, (select sum(Price) from Items where Id in ("+String.Join(",",model.ItemsIds)+"))) ");
            foreach(var i in model.ItemsIds)
            {
                query.AppendLine("insert into OrderItems(OrderId, ItemId) values((select Id from @newId)," + i+") ");
            }
            query.AppendLine(" commit;");

            int affectedRows = db.Execute(query.ToString(), new { model.UserId, model.RegionId });

            return affectedRows > 0;
        }

        public bool Update(OrdersModel model, int Id)
        {
            StringBuilder query = new StringBuilder();
            query.Append("begin transaction update Orders set RegionId = @RegionId, Sum = (select sum(Price) from Items where Id in (" + String.Join(",", model.ItemsIds) + ")) where Id = @Id");
            query.AppendLine(" delete from OrderItems where OrderId = @Id ");
            foreach (var i in model.ItemsIds)
            {
                query.AppendLine(" insert into OrderItems(OrderId, ItemId) values(@Id," + i + ") ");
            }
            query.AppendLine(" commit;");
            int affectedRows = db.Execute(query.ToString(), model);
            return affectedRows > 0;
        }

        public bool Delete(int id)
        {
            string query = "DELETE FROM Orders WHERE Id=@Id";
            int affectedRows = db.Execute(query, new { Id = id });
            return affectedRows > 0;
        }

        public IEnumerable<OrdersModel> GetList()
        {
            throw new NotImplementedException();
        }
        public static IEnumerable<OrdersModel> GetOrdersBetweenDates(DapperService db, DateTime from, DateTime to)
        {
            
                List<OrdersModel> items = new List<OrdersModel>();
                db.ClearParams();
                db.AddParam("@from", DbType.DateTime, from);
                db.AddParam("@to", DbType.DateTime, to);
                string query = @" select distinct o.*, u.FirstName + ' ' + u.LastName as CustomerName from Orders o
	left join Users u on u.Id = o.UserId
where o.CreatedTime between CONVERT(datetime,@from) and CONVERT(datetime,@to)  order by o.Id";
                using (IDataReader reader = db.Select(query))
                {
                    while (reader.Read())
                    {
                        OrdersModel ret = new OrdersModel();
                        ret.Id = (int)reader["Id"];
                        ret.Status = (int)reader["Status"];
                        ret.Sum = (decimal)reader["Sum"];
                        ret.CreatedTime = (DateTime)reader["CreatedTime"];
                        ret.UserId = ret.User.Id = (int)reader["UserId"];
                        ret.RegionId = ret.User.Id = (int)reader["RegionId"];
                        ret.Region.Name = RegionsService.GetRegionFullAreaName(db, ret.RegionId);
                        ret.User.FullName = (string)reader["CustomerName"];
                        items.Add(ret);
                    }
                }
                return items;
        }

        public static IEnumerable<OrdersModel> GetOrdersByRegionId(DapperService db, int regionId)
        {

            List<OrdersModel> items = new List<OrdersModel>();
            db.ClearParams();
            db.AddParam("@regionId", DbType.Int32, regionId);
            string query = @" select distinct o.*, u.FirstName + ' ' + u.LastName as CustomerName from Orders o
	        left join Users u on u.Id = o.UserId
        where o.RegionId = @regionId  order by o.Id";
            using (IDataReader reader = db.Select(query))
            {
                while (reader.Read())
                {
                    OrdersModel ret = new OrdersModel();
                    ret.Id = (int)reader["Id"];
                    ret.Status = (int)reader["Status"];
                    ret.Sum = (decimal)reader["Sum"];
                    ret.CreatedTime = (DateTime)reader["CreatedTime"];
                    ret.UserId = ret.User.Id = (int)reader["UserId"];
                    ret.RegionId = ret.User.Id = (int)reader["RegionId"];
                    ret.Region.Name = RegionsService.GetRegionFullAreaName(db, ret.RegionId);
                    ret.User.FullName = (string)reader["CustomerName"];
                    items.Add(ret);
                }
            }
            return items;
        }
    }
}
