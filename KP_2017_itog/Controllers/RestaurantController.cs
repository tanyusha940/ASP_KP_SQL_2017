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
            ModelState.Clear();
            return View(restauntRepository.GetAllRestaurant());
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
        public ActionResult AddRestaurant(Restaurants restaurant)
        {

                if (ModelState.IsValid)
                {

                    restauntRepository.AddRestaurant(restaurant);
                    
                }

                return View(restaurant);

        }

        public ActionResult EditEmpDetails(int id)
        {

            return View(restauntRepository.GetAllRestaurant().Find(x => x.Restaurant_ID == id));

        }

        [HttpPost]
        public ActionResult EditRestaurant(int id, Restaurants obj)
        {
            try
            {

                restauntRepository.UpdateRestaurant(obj);

                return RedirectToAction("GetAllRestaurants");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5
        public ActionResult DeleteEmp(int id)
        {
            try
            {
              
                if (restauntRepository.DeleteRestaurant(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllRestaurants");

            }
            catch
            {
                return View();
            }
        }
    }
}
