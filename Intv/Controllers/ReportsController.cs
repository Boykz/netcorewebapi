using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Intv.Helpers;
using Intv.Models;
using Intv.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Intv.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly DapperService dapperService;
        public ReportsController(DapperService _dapperService)
        {
            dapperService = _dapperService;
        }
        /// <summary>
        /// Список заказов между датами
        /// </summary>
        /// <param name="from">От - 2021-05-01</param>
        /// <param name="to">До - 2021-05-04</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get(DateTime from, DateTime to)
        {
            if (to < from)
            {
                return Content($"to дата не может быть менше чем from дата");
            }
            if (to > DateTime.Today || from > DateTime.Today)
            {
                return Content($"даты не может быть больше чем {DateTime.Today}");
            }

            IEnumerable<OrdersModel> orders = OrdersService.GetOrdersBetweenDates(dapperService, from, to);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Orders");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Сумма";
                worksheet.Cell(currentRow, 3).Value = "Клиент";
                worksheet.Cell(currentRow, 4).Value = "Дата создание";
                worksheet.Cell(currentRow, 5).Value = "Регион";
                foreach (var order in orders)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.Id;
                    worksheet.Cell(currentRow, 2).Value = order.User.FullName;
                    worksheet.Cell(currentRow, 3).Value = order.Sum;
                    worksheet.Cell(currentRow, 4).Value = order.CreatedTime;
                    worksheet.Cell(currentRow, 5).Value = order.Region.Name.Trim();
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Заказы.xlsx");
                }
            }
        }

        /// <summary>
        /// Список заказов по региону
        /// </summary>
        /// <param name="id">Регион id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetResult(int id)
        {
            if (!RegionsService.checkForExists(dapperService, id))
            {
                return Content($"RegionId = {id} не существует в базе");
            }
            IEnumerable<OrdersModel> orders = OrdersService.GetOrdersByRegionId(dapperService, id);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Orders");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Id";
                worksheet.Cell(currentRow, 2).Value = "Сумма";
                worksheet.Cell(currentRow, 3).Value = "Клиент";
                worksheet.Cell(currentRow, 4).Value = "Дата создание";
                worksheet.Cell(currentRow, 5).Value = "Регион";
                foreach (var order in orders)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = order.Id;
                    worksheet.Cell(currentRow, 2).Value = order.User.FullName;
                    worksheet.Cell(currentRow, 3).Value = order.Sum;
                    worksheet.Cell(currentRow, 4).Value = order.CreatedTime;
                    worksheet.Cell(currentRow, 5).Value = order.Region.Name.Trim();
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "ЗаказыПоРегиону.xlsx");
                }
            }
        }
    }
}