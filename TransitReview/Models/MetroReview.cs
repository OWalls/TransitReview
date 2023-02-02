namespace TransitReview.Models
{
    public class MetroReview
    {
        public int MetroId { get; set; }
        public Metro Metro { get; set; }
        public int ReviewId { get; set; }
        public Review Review { get; set; }
    }
}
