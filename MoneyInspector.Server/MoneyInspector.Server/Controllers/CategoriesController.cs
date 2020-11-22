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

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
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
    }
}
