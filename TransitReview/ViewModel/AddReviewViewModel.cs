using System.ComponentModel.DataAnnotations;

namespace TransitReview.ViewModel
{
    public class AddReviewViewModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
