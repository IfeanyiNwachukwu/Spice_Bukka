namespace SpicyBukka.Models
{
    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Spicyness { get; set; }
        public enum ESpicy { NA=0, NotSPicy=1, Spicy=2, VerySpicy=3 }
    }
}
