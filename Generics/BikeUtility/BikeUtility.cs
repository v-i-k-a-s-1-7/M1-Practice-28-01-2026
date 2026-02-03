namespace Sample
{
    public class BikeUtility
    {
        public static SortedDictionary<int, Bike> bikeDetails = new SortedDictionary<int, Bike>();
        public void AddBikeDetails(string model, string brand, int PricePerDay)
        {

            int key = bikeDetails.Count + 1;
            bikeDetails.Add(key,new Bike(model,brand,PricePerDay));

        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> groupedBikes = new SortedDictionary<string, List<Bike>>();

            foreach (var bike in bikeDetails.Values)
            {
                if (!groupedBikes.ContainsKey(bike.Brand))
                {
                    groupedBikes[bike.Brand] = new List<Bike>();
                }
                groupedBikes[bike.Brand].Add(bike);
            }

            return groupedBikes;
        }
    }
}