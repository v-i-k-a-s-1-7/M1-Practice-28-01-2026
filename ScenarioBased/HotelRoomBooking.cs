namespace ScenarioBased
{
    public class RoomNotAvailable : Exception
    {
        public RoomNotAvailable(string message) : base(message)
        {

        }
    }
    
    public class Room
    {
        public int RoomNumber{get; set;}
        public string RoomType{get;set;}
        public double PricePerNight{get;set;}
        public bool IsAvailable{get;set;}

        public Room()
        {
            
        }
        public override string ToString()
        {
            return $"Room Number: {RoomNumber}, Room Type: {RoomType}, Price Per Night: {PricePerNight}";
        }
    }

    public class HotelManager
    {
        public List<Room> rooms = new List<Room>();

        public void AddRoom(int roomNumber, string type, double price)
        {
            foreach(var item in rooms)
            {
                if (item.RoomNumber == roomNumber)
                {
                    throw new RoomNotAvailable("Room Number not Available");
                }
            }
            rooms.Add(new Room
            {
                RoomNumber = roomNumber,
                RoomType = type,
                PricePerNight = price,
                IsAvailable = true
            });
        } 

        public Dictionary<string,List<Room>> GroupRoomsByType()
        {
            Dictionary<string,List<Room>> roomsDict = new Dictionary<string, List<Room>>();

            foreach(var item in rooms)
            {
                if (!item.IsAvailable)
                {
                    continue;
                }

                if (!roomsDict.ContainsKey(item.RoomType))
                {
                    roomsDict[item.RoomType] = new List<Room>();
                }

                roomsDict[item.RoomType].Add(item);
            }

            return roomsDict;
        }

        public bool BookRoom(int roomNumber, int nights)
        {
            double totalCost = 0;
            foreach(var item in rooms)
            {
                if(item.RoomNumber == roomNumber && item.IsAvailable)
                {
                    item.IsAvailable = false;
                    totalCost = item.PricePerNight * nights;
                    return true;
                }
            }
            return false;
        }

        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            List<Room> availableRooms = new List<Room>();
            foreach(var item in rooms)
            {
                if(item.PricePerNight <= max && item.PricePerNight >= min && item.IsAvailable)
                {
                    availableRooms.Add(item);
                }
            }
            return availableRooms;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            HotelManager rooms = new HotelManager();
            rooms.AddRoom(101,"Single",1200.00);
            rooms.AddRoom(102,"Double",2200.00);
            rooms.AddRoom(103,"Single",1600.00);
            rooms.AddRoom(104,"Suite",8000.00);

            foreach(var room in rooms.GroupRoomsByType())
            {
                Console.Write($"Room Type: {room.Key} ");

                foreach(var item in room.Value)
                {
                    Console.Write($"{item.RoomNumber} ");
                }
                Console.WriteLine();
            }

            rooms.BookRoom(101,4);
            rooms.BookRoom(102,2);

            List<Room> listOfRooms = new List<Room>();
            listOfRooms = rooms.GetAvailableRoomsByPriceRange(1000,2000);

            foreach(var item in listOfRooms)
            {
                Console.Write($"{item} ");
            }

        }
    }
}