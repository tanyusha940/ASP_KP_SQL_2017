using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using KP_2017_itog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantRepository restauntRepository;
        private readonly CityRepository cityRepository;
        private readonly Ref_Types_of_KitchenRepository ref_Types_Of_KitchenRepository;
        private readonly CountryRepository countryRepository;
        
        public RestaurantController()
        {
            restauntRepository = new RestaurantRepository();
            cityRepository = new CityRepository();
            countryRepository = new CountryRepository();
            ref_Types_Of_KitchenRepository = new Ref_Types_of_KitchenRepository();


        }
        public ActionResult GetAllRestaurants()
        {
            List<Restaurants> restaurants = new List<Restaurants>();
            restaurants = restauntRepository.GetAllRestaurant();
            if(restaurants != null)
            {
                return View(restaurants);
            }
            return View();
        }

        public ActionResult AddRestaurant()
        {
            var viewModel = new RestaurantViewModel()
            {
                City = cityRepository.GetAllCity(),
                Country = countryRepository.GetAllCountries(),
                TypeKitchen = ref_Types_Of_KitchenRepository.GetAllTypeOfKitchen()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurants restaurant, Restaurants_Type_of_Kitchen type)
        {
            if (ModelState.IsValid)
            {
                if(restauntRepository.AddRestaurant(restaurant, type))
                {                 
                    TempData["message"] = $"Ресторан успешно создан";
                    return RedirectToAction("GetAllRestaurants", "Restaurant");
                }
            }
            return View();
        }

        public ActionResult EditRestaurant(int id)
        {

            return View(restauntRepository.GetAllRestaurant().Find(x => x.Restaurant_ID == id));

        }

        [HttpPost]
        public ActionResult EditRestaurant(int id, Restaurants obj)
        {
            if (ModelState.IsValid)
            { 
                restauntRepository.UpdateRestaurant(obj);
                return RedirectToAction("GetAllRestaurants", "Restaurant");
            }
            return View();
        }

        public ActionResult DeleteRestaurant(int id)
        {
            restauntRepository.DeleteRestaurant(id);
            TempData["message"] = $"Ресторан успешно удален";
            return RedirectToAction("GetAllRestaurants", "Restaurant");    
        }
    }
}
