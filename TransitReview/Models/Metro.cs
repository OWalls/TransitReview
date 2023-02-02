namespace TransitReview.Models
{
    public class Metro
    {
        public int Id { get; }
        static private int nextId = 1;
        //public int MetroId { get; set; }
        public string Name { get; set; }
        public string BusConnect { get; set; }
        public string City { get; set; }

        public Metro()
        {
           
        }

        public Metro(string name, string busConnect, string city)
        {
            Name = name;
            BusConnect = busConnect;
            City = city;
            Id = nextId;
            nextId++;
        }
    }
}
