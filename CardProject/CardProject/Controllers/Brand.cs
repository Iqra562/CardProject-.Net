using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CardProject.Controllers
{
    public class Brand:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
