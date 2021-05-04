using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Intv.Helpers;
using Intv.Models;
using Intv.Services;
using Intv.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Intv.Controllers
{
    [Route("api/[controller]")]
    
    public class OrdersController : Controller
    {
        private readonly IOrdersService ordersService;
        private readonly DapperService dapperService;
        public OrdersController(IOrdersService service, DapperService _dapperService)
        {
            dapperService = _dapperService;
            ordersService = service;
        }
        /// <summary>
        /// Список заказов с пагинации
        /// </summary>
        /// <param name="itemName">Название товара</param>
        /// <param name="regionName">Название региона</param>
        /// <param name="page">Страница</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public JsonResult Get(string itemName, string regionName, int page = 1)
        {
            if(page < 1)
            {
                page = 1;
            }
            int itemsCount = 0;
            var result = ordersService.GetList(itemName, regionName, page, ref itemsCount);
            if(itemsCount == 0 || result.Count() == 0)
            {
                return Json(new { message = "Не найден" });
            }
            Pagination pagination = new Pagination(itemsCount, page);
            return Json(new { Orders = result.Select(x=> new { x.Id,
                x.CreatedTime,
                x.Sum,
                CustomerName = x.User.FullName,
                RegionName = x.Region.Name
            }), pagination });
        }

        /// <summary>
        /// Получение заказа по Id
        /// </summary>
        /// <param name="id">Id заказа</param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            if (id < 1)
            {
                return Json(new { message = "заказ не найден" });
            }
            OrdersModel result = ordersService.Get(id);

             if(result == null)
             {
                 return Json(new { message = "заказ не найден" }); ;
             }
            return Json(new { message = $"Заказы {result.User.FullName} Кол-во товаров:{result.Items.Count}",
                order = new {
                    cutomerName = result.User.FullName,
                    result.Sum, regionName = result.Region.Name, result.CreatedTime                    
                },
                result.Items,
            }); ;

        }
        /// <summary>
        /// Добавление заказа (role:Customer)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Authorize(Roles = "Customer")]
        [HttpPost]
        public JsonResult Post([FromBody] OrdersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
            if (model.Items == null || model.Items.Count() == 0)
            {
                return Json(new { message = "Список товаров не может быть пустыми" });
            }
            if (!Int32.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value, out int id))
            {
                return Json(new { message = "Пользователь не существует" });
            }
            IEnumerable<int> validItems =  ItemsService.getValidItemsList(dapperService, model.Items).Select(x => x.Id);
            if (validItems == null || validItems.Count() == 0)
            {
                return Json(new { message = "Следующие товары не существует в базе", model.Items });
            }
            List<int> inValidItems = new List<int>();
            foreach(var i in model.Items)
            {
                if(!validItems.Contains(i)){
                    inValidItems.Add(i);
                }
            }
            if(inValidItems != null && inValidItems.Count() > 0)
            {
                return Json(new { message = "Следующие товары не существует в базе" , Items = inValidItems });
            }
            if (!RegionsService.checkForExists(dapperService, model.RegionId))
            {
                return Json(new { message = $"RegionId={model.RegionId} не существует в базе"});
            }
            OrdersModel items = new OrdersModel(model){
                UserId = id
            };
            bool isSaved = ordersService.Save(items);

            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Изменение заказа (role:Customer)
        /// </summary>
        /// <param name="id">Заказ Id</param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        //[Authorize(Roles = "Customer")]
        public JsonResult Put(int id, [FromBody] OrdersViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
            if (model.Items == null || model.Items.Count() == 0)
            {
                return Json(new { message = "Список товаров не может быть пустыми" });
            }
            IEnumerable<int> validItems = ItemsService.getValidItemsList(dapperService, model.Items).Select(x => x.Id);
            if (validItems == null || validItems.Count() == 0)
            {
                return Json(new { message = "Следующие товары не существует в базе", model.Items });
            }
            List<int> inValidItems = new List<int>();
            foreach (var i in model.Items)
            {
                if (!validItems.Contains(i))
                {
                    inValidItems.Add(i);
                }
            }
            if (inValidItems != null && inValidItems.Count() > 0)
            {
                return Json(new { message = "Следующие товары не существует в базе", Items = inValidItems });
            }
            if (!RegionsService.checkForExists(dapperService, model.RegionId))
            {
                return Json(new { message = $"RegionId={model.RegionId} не существует в базе" });
            }

            OrdersModel item = new OrdersModel()
            {
                Id = id,
                RegionId = model.RegionId,
                ItemsIds = model.Items
            };
            bool isSaved = ordersService.Update(item, id);

            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Удаление заказа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Authorize(Roles = "Administrator")]
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            if (id < 1)
            {
                return Json(new { message = "Не cохранено" });
            }

            bool isDeleted = ordersService.Delete(id);

            return Json(new { message = isDeleted ? "Удалено" : "Не удалено" });

        }
    }
}
