using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using LocalLookupMVC.Models;
using System;

namespace LocalLookupMVC.Controllers
{
    public class CitiesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LocalLookupMVCContext _db;

        public CitiesController(UserManager<ApplicationUser> userManager, LocalLookupMVCContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index(int page = 1, int pageCount = 2)
        {
            IQueryable<Object> charQuery = City.GetCities().AsQueryable();
            if (page <= 0)
            {
                page = 1;
            }
            ViewBag.pageCount = pageCount;
            charQuery = PaginationHelper.GetPaged(charQuery, page, pageCount);
            List<City> results = charQuery.Cast<City>().ToList();
            ViewBag.page = page;
            return View(results);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(City.GetCities(), "CityId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(City city, int CityId)
        {
            City.Post(city);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            City thisCity = City.GetDetails(id);
            return View(thisCity);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            City thisCity = City.GetDetails(id);

            return View(thisCity);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {

            City.Put(city);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            City thisCity = City.GetDetails(id);
            return View(thisCity);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            City.Delete(id);
            return RedirectToAction("Index");
        }
    }
}