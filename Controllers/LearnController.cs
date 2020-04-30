using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LearnSystemTextJson.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnSystemTextJson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearnController : ControllerBase
    {
        [HttpGet("Serialize")]
        public ActionResult Serialize()
        {
            var category = GetOne();
            string returnJson = JsonSerializer.Serialize(category);
            return Ok("Check via Debugging");
        }
        [HttpGet("Deserialize")]
        public ActionResult Deserialize()
        {
            var param = "{\"Id\":\"321d3b8b-7184-497c-8a55-80c5e66ead2a\",\"Name\":\"Baju Pria\"}";
            Category category = JsonSerializer.Deserialize<Category>(param);
            return Ok("Check via Debugging");
        }


        [HttpGet("DynamicParam")] //Working With Dynamic Param
        public ActionResult DynamicParam(dynamic param)
        {
            /*
             {
	            "Id":"321d3b8b-7184-497c-8a55-80c5e66ead2a",
	            "Name":"Fashion Pria"
             }
             */
            string stringParam = JsonSerializer.Serialize(param);
            Category category = JsonSerializer.Deserialize<Category>(stringParam);
            return Ok("Check via Debugging");
        }


        private List<Category> GetAll()
        {
            List<Category> categories = new List<Category>();
            var categori1 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Fashion Pria"
            };
            var categori2 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Fashion Wanita"
            };
            var categori3 = new Category()
            {
                Id = Guid.NewGuid(),
                Name = "Baju Pria"
            };
            categories.Add(categori1);
            categories.Add(categori2);
            categories.Add(categori3);
            return categories;
        }
        private Category GetOne()
        {
            return new Category() {
                Id = Guid.NewGuid(),
                Name = "Baju Pria"
            };
        }
    }
}