namespace Laba_7.Models
{
    public class Pharma
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Type: {Type}";
        }
    }
}
