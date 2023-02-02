namespace TransitReview.Models
{
    public abstract class MetroField
    {
        public int Id { get; }
        static private int nextId = 1;
        public string Value { get; set; }

        public MetroField()
        {
            Id = nextId;
            nextId++;
        }

        public MetroField(string value) : this()
        {
            Value = value;

        }

        public override string ToString()
        {
            return Value;
        }

        public override bool Equals(object obj)
        {
            return obj is MetroField field &&
                   Id == field.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
