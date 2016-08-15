using OdeToFood_DotNetCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood_DotNetCore.Services
{   
    public class InMemoryRestaurantData : IRestaurantData
    {
        static List<Restaurant> _restaurants;

        static InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name= "Tersiguel's",Cuisine = CuisineType.American},
                new Restaurant { Id = 2, Name= "LJ's and the Kat",Cuisine = CuisineType.Italian},
                new Restaurant { Id = 3, Name= "King's Contrivance",Cuisine = CuisineType.French}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(r => r.Id == id);
        }

        public void Add(Restaurant newRestaurant)
        {
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            _restaurants.Add(newRestaurant);
        }

        public int Commit()
        {
            return 0;
        }
    }
}
