using KP_2017_itog.Models;
using KP_2017_itog.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KP_2017_itog.Controllers
{
    public class RestaurantController : Controller
    {
        public ActionResult GetAllRestaurants()
        {

            RestaurantRepository restaurantRepositpry = new RestaurantRepository();
            ModelState.Clear();
            return View(restaurantRepositpry.GetAllRestaurant());
        }

        public ActionResult AddRestaurant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRestaurant(Restaurants restaurant)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    RestaurantRepository restaurantRepositpry = new RestaurantRepository();

                    if (restaurantRepositpry.AddRestaurant(restaurant))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditEmpDetails(int id)
        {
            RestaurantRepository restaurantRepositpry = new RestaurantRepository();

            return View(restaurantRepositpry.GetAllRestaurant().Find(x => x.Restaurant_ID == id));

        }

        [HttpPost]
        public ActionResult EditRestaurant(int id, Restaurants obj)
        {
            try
            {
                RestaurantRepository restaurantRepositpry = new RestaurantRepository();

                restaurantRepositpry.UpdateRestaurant(obj);

                return RedirectToAction("GetAllEmpDetails");
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
                RestaurantRepository restaurantRepositpry = new RestaurantRepository();
                if (restaurantRepositpry.DeleteRestaurant(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}
