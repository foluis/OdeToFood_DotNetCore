using OdeToFood_DotNetCore.Entities;
using System.Collections.Generic;

namespace OdeToFood_DotNetCore.ViewModels
{
    public class HomePageViewModel
    {        
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentGreetings { get; set; }
    }
}
