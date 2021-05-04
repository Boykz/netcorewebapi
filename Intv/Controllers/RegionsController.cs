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
    public class RegionsController : Controller
    {
        private readonly IRegionsService regionsService;
        public RegionsController(IRegionsService service)
        {
            regionsService = service;
        }
        /// <summary>
        /// Список регионов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Get()
        {
            var result = regionsService.GetList();

            return Json(new { message = result });
        }
        /// <summary>
        /// Полуние региона по IDd
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public JsonResult Get(int id, [FromServices] DapperService db)
        {
            if (id < 1)
            {
                return Json(new { message = "не найден" });
            }
            IEnumerable<RegionsModel> regionsModel = RegionsService.GetFull(db, id);

             if(regionsModel == null || regionsModel.Count() == 0)
             {
                 return Json(new { message = "не найден" }); ;
             }
            return Json(new { message = regionsModel }); ;

        }

        /// <summary>
        /// Добавление региона
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Post([FromBody] RegionsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { message = Validation.getValidationErrors(model) });
            }
            RegionsModel items = new RegionsModel(model);

            bool isSaved = regionsService.Save(items);

            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Обновление региона
        /// </summary>
        /// <param name="id">Id региона</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] RegionsViewModel model)
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
            RegionsModel item = new RegionsModel(model)
            {
                Id = id
            };
            bool isSaved = regionsService.Update(item, id);

            return Json(new { message = isSaved ? "Сохранено" : "Не cохранено" });
        }

        /// <summary>
        /// Удаление региона
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            if (id < 1)
            {
                return Json(new { message = "Не cохранено" });
            }

            bool isDeleted = regionsService.Delete(id);

            return Json(new { message = isDeleted ? "Удалено" : "Не удалено" });

        }
    }
}
