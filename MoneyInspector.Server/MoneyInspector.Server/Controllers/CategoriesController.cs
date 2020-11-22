using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyInspector.Server.Models;
using MoneyInspector.Server.Services.Interfaces;

namespace MoneyInspector.Server.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService categoriesService;
        private readonly IDateTimeParser dateTimeParser;

        public CategoriesController(ICategoriesService categoriesService, IDateTimeParser dateTimeParser)
        {
            this.categoriesService = categoriesService;
            this.dateTimeParser = dateTimeParser;
        }

        [HttpGet("getAllWithSum")]
        public IActionResult GetAllCategoriesWithSum()
        {
            return Ok(categoriesService.GetAllCategorySums());
        }

        [HttpGet("getAllWithoutSum")]
        public IActionResult GetAllCategoriesWithoutSum()
        {
            return Ok(categoriesService.GetAllCategories());
        }

        [HttpGet("getByPeriodWithSum")]
        public IActionResult GetCategoriesByPeriodWithSum(long startDateMs, long endDateMs)
        {
            return Ok(categoriesService.GetCategorySumsByPeriod(dateTimeParser.GetDateTimePeriod(startDateMs, endDateMs)));
        }

        [HttpGet("getByPeriodWithoutSum")]
        public IActionResult GetCategoriesByPeriodWithoutSum(long startDateMs, long endDateMs)
        {
            return Ok(categoriesService.GetCategoriesByPeriod(dateTimeParser.GetDateTimePeriod(startDateMs, endDateMs)));
        }
    }
}
