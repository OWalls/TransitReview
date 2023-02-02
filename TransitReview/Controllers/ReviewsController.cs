using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Runtime.InteropServices;
using TransitReview.Models;
using TransitReview.ViewModel;
using TransitReview.Data;
using System.Xml.Linq;
using System.Security.Cryptography;

namespace TransitReview.Controllers
{
    public class ReviewsController : Controller
    {
        
        public IActionResult Index()
        {
            List<Review> Reviews = new List<Review>(MetroData.GetAll());
            ViewBag.reviews = Reviews;
            return View();
        }

        public IActionResult Add()
        {
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel();
            return View(addReviewViewModel);
        }

        [HttpPost]
        [Route("Reviews/Add/{id}")]
        public IActionResult Add(AddReviewViewModel addReviewViewModel, string id)
        {
            //List<Metro> metros = MetroData.FindAll();
            //if (!String.IsNullOrEmpty(HttpContext.Request.Query["id"]))
            //    string qId = HttpContext.Request.Query["id"];
             
            Review newReview = new Review
            {
                Username = addReviewViewModel.Username,
                Title = addReviewViewModel.Title,
                Comment = addReviewViewModel.Comment,
                MetroId = Int32.Parse(id)
            };

            MetroData.Add(newReview);

            return Redirect("/Reviews"); ;
        }
    }
}
