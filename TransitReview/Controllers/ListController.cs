using Microsoft.AspNetCore.Mvc;
using TransitReview.Data;
using TransitReview.Models;

namespace TransitReview.Controllers
{
    public class ListController : Controller
    {

        public static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"stop", "Stop" },
            {"city", "City" }
        };

        /*internal static Dictionary<string, List<MetroField>> TableChoices = new Dictionary<string, List<MetroField>>()
        {
           
        }; */

       
        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            //ViewBag.tableChoices = TableChoices;
            return View();
        }

        // list metros by column and value
        public IActionResult Metros(string column, string value)
        {
            List<Metro> metros;
            
            if (column.ToLower().Equals("all"))
            {
                metros = MetroData.FindAll();
                ViewBag.title = "All Metro Link Stations";
            }
            else
            {
                metros = MetroData.FindAll();
            } 

            ViewBag.metros = metros;
            return View();
        }


    }
}
