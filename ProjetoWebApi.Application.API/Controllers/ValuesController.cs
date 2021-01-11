using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoWebApi.Domain.Entities.Logins;
using ProjetoWebAPI.Service.Business.Authentication;

namespace ProjetoWebApi.Application.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        ValidationBusiness business { get; set; }

        public ValuesController()
        {
            business = new ValidationBusiness();
        }

        [HttpPost("isvalid")]
        public JsonResult IsValid([FromBody] string data)
        {
            var model = new LoginResponseDTO();
            model.IsValidPassword = business.IsValidPassword(data);
            return Json(model);
        }
    }
}
