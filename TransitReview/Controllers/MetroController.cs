using Microsoft.AspNetCore.Mvc;
using TransitReview.Data;
using TransitReview.Models;

namespace TransitReview.Controllers
{
    public class MetroController : Controller
    {
        public IActionResult Index()
        {
            List<Metro> metros;
            metros = MetroData.FindAll();
            ViewBag.metros = metros;
            return View();
        }
    }
}
