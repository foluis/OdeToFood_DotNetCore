using Microsoft.AspNetCore.Mvc;
using OdeToFood_DotNetCore.Entities;
using OdeToFood_DotNetCore.Services;
using OdeToFood_DotNetCore.ViewModels;

namespace OdeToFood_DotNetCore.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;
        private IGreeter _greeter;

        public HomeController(
            IRestaurantData restaurantData,
            IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

        public ViewResult Index()
        {
            var model = new HomePageViewModel();
            model.Restaurants = _restaurantData.GetAll();
            model.CurrentGreetings = _greeter.GetGreeting();
            return View(model);
        }

        //[HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, Restaurant model)
        {
            var restaurant = _restaurantData.Get(id);
            if (restaurant != null && ModelState.IsValid)
            {
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;
                _restaurantData.Commit();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RestaurantEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var restaurant = new Restaurant();
                restaurant.Name = model.Name;
                restaurant.Cuisine = model.Cuisine;

                _restaurantData.Add(restaurant);
                _restaurantData.Commit();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public IActionResult Test3()
        {
            var model = new Restaurant
            {
                Id = 1,
                Name = "Sabatino's"
            };
            return View(model);
        }

        //Very convenient for a API !!
        public ObjectResult Test2()
        {
            var model = new Restaurant
            {
                Id = 1,
                Name = "Sabatino's"
            };
            return new ObjectResult(model);
        }

        public IActionResult Test1()
        {
            var model = new Restaurant
            {
                Id = 1,
                Name = "Sabatino's"
            };
            return Content("Hello From home controller");
        }


    }
}
