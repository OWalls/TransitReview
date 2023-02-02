namespace TransitReview.Models
{
    public class Review
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Username { get; set; }
        public string Title { get; set;}
        public string Comment { get; set; }
        public List<Metro> Metros { get; set; }
        public int MetroId { get; set; }
        //public string Rating { get; set; }

        public Review()
        {
            Id = nextId;
            nextId++;
        }

        public Review(string username, string title, string comment)
        {
            Username= username;
            Title= title;
            Comment= comment;
            //Metros = new List<Metro>();
    
            //foreach (var metro in Metros)
            //{
            //    MetroId= metro.Id;
            //}
        }
    }
}
