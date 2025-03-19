using Microsoft.AspNetCore.Mvc;

namespace CRUDDemo.Controllers
{
    
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Redirect("/api/employee");
        }
    }
}
