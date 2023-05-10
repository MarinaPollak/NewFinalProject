
using System.Collections.Generic;
/* 
[CityBuilder] 
[C# WPF Game] 
[Marina Pollak]
[05/09/2022] 
tutor Thomas Maggraff https://github.com/gurrenm3
*/


namespace NewFinalProject.Classes
{
    public class City
    {
        public List<string> buildingTypes = new List<string>()
        {
            "Transportaion",
            "Restaurants",
            "Entertainment",
        };

        public List<string> transportationTypes = new List<string>()
        {
            "Car",
            "Truck",
            "Plane",
            "Boat",
            "Train"
        };

        public List<string> restaurantTypes = new List<string>()
        {
            "Mexican",
            "Italian",
            "French",
            "Dessert",
            "Pizza"
        };

        public List<string> entertainmentTypes = new List<string>()
        {
            "Movies",
            "Clubs",
            "Bowling",
            "Sports"
        };

        public List<Transportation> transportations = new List<Transportation>();
        public List<Restaurant> restaurants = new List<Restaurant>();
        public List<Entertainment> entertainments = new List<Entertainment>();

        public City()
        {
            CreateAllRestaurants();
            CreateAllTransportations();
            CreateAllEntertainment();
        }

        public void AddEntertainment(string name, int cost, int score)
        {
            Entertainment entertainment = new Entertainment();
            entertainment.Name = name;
            entertainment.Cost = cost;
            entertainment.Score = score;
            entertainment.BuildingType = "Entertainment";

            entertainments.Add(entertainment);
        }

        public void CreateAllEntertainment()
        {
            entertainments.Clear();

            AddEntertainment(entertainmentTypes[0], 100_000, 100);
            AddEntertainment(entertainmentTypes[1], 150_000, 150);
            AddEntertainment(entertainmentTypes[2], 170_000, 170);
            AddEntertainment(entertainmentTypes[3], 300_000, 550);
        }

        public void AddTransportation(string name, int cost, int score)
        {
            Transportation transportation = new Transportation();
            transportation.Name = name;
            transportation.Cost = cost;
            transportation.Score = score;
            transportation.BuildingType = "Transportation";

            transportations.Add(transportation);
        }

        public void CreateAllTransportations()
        {
            transportations.Clear();

            AddTransportation(transportationTypes[0], 10_000, 10);
            AddTransportation(transportationTypes[1], 50_000, 15);
            AddTransportation(transportationTypes[2], 1700_000, 1170);
            AddTransportation(transportationTypes[3], 500_000, 550);
            AddTransportation(transportationTypes[4], 2000_000, 2000);
        }

        public void AddRestaurant(string name, int cost, int score)
        {
            Restaurant restaurant = new Restaurant();
            restaurant.Name = name;
            restaurant.Cost = cost;
            restaurant.Score = score;
            restaurant.BuildingType = "Restaurant";

            restaurants.Add(restaurant);
        }

        public void CreateAllRestaurants()
        {
            restaurants.Clear();

            AddRestaurant(restaurantTypes[0], 400_000, 100);
            AddRestaurant(restaurantTypes[1], 600_000, 150);
            AddRestaurant(restaurantTypes[2], 700_000, 170);
            AddRestaurant(restaurantTypes[3], 200_000, 50);
            AddRestaurant(restaurantTypes[4], 300_000, 70);
        }

    }
}