using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class FallbackController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            // return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "wwwroot", "index.html"), "text/HTML");
            // return PhysicalFile(Path.Combine("wwwroot", "index.html"), "text/HTML");
            return File("~/wwwroot/index.html", "text/HTML");
        } 
    }
}