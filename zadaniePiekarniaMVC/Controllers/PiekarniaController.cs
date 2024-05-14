using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace zadaniePiekarniaMVC.Controllers
{
    public class PiekarniaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        

    }
}
