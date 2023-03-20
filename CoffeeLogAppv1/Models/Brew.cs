namespace CoffeeLogAppv1.Models
{
    public class Brew
    {
        // props for brew logs
        public int Id { get; set; }
        public string CoffeeName { get; set; }
        public double BrewTime { get; set; }
        public double DoseGrams { get; set; }
        public int GrindSetting { get; set; }
        public int WaterTemp { get; set; }
        public string Notes { get; set; }

        // constructor
        public Brew()
        {
            
        }
    }
}
