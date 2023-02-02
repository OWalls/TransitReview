using Microsoft.AspNetCore.Mvc;
using TransitReview.Data;
using TransitReview.Models;

namespace TransitReview.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.ColumnChoices;
            return View();
        }

        //search
        public IActionResult Results(string searchType, string searchTerm)
        {
            List<Metro> searchMetros;

            if (searchTerm == "" || searchTerm == null)
            {
                searchMetros = MetroData.FindAll();
            }
            else
            {
                searchMetros = MetroData.FindByColumnAndValue(searchType, searchTerm);
            }
            ViewBag.metros = searchMetros;
            ViewBag.columns = ListController.ColumnChoices;
            ViewBag.title = "Metro Stations with " + ListController.ColumnChoices[searchType] + ": " + searchTerm;

            return View("Index");
        }
    }
}
