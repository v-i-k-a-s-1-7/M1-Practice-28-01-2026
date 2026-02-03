namespace Sample
{
    
    public class Bike
    {
        public string Model{get; set;}
        public string Brand{get; set;}
        public int PricePerDay{get;set;}

        public Bike(string model, string brand, int pricePerDay)
        {
            this.Model = model;
            this.Brand = brand;
            this.PricePerDay = pricePerDay;
        }

    }
}