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
    [Authorize(Roles = "Administrator")]
    public class ItemsController : Controller
    {
        private readonly IItemsService itemsService;
        public ItemsController(IItemsService _service)
        {
            itemsService = _service;
        }
        /// <summary>
        /// Список товаров
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get()
        {
            IEnumerable<ItemsModel> result = itemsService.GetList();

            return Json(new { message = result });
        }

        /// <summary>
        /// Товар по Id
        /// </summary>
        /// <param name="id"> Id товара</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            if (id < 1)
            {
                return Json(new { message = "Товар не найден" });
            }
            ItemsModel itemsModel = itemsService.Get(id);

             if(itemsModel == null)
             {
                 return Json(new { message = "Товар не найден" }); ;
             }

            return Json(new { message =  itemsModel}); ;
            
        }

        /// <summary>
        /// Добавление товара
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Post([FromBody] ItemsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
            ItemsModel items = new ItemsModel(model);

            bool isSaved = itemsService.Save(items);
            
            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Обновление товара
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <param name="model">Тело</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] ItemsViewModel model)
        {
            if (id < 1 || model == null)
            {   
                return Json(new { message = "Не cохранено" });
            }
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
            ItemsModel item = new ItemsModel(model) {
                Id = id
            };
            bool isSaved = itemsService.Update(item, id);

            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Удаление товара по Id
        /// </summary>
        /// <param name="id">Id товара</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            if (id < 1)
            {
                return Json(new { message = "Не cохранено" });
            }

            bool isDeleted = itemsService.Delete(id);

            return Json(new { message = isDeleted ? "Удалено" : "Не удалено" });

        }
    }
}
