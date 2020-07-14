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
            if(page <= 0 ){
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
            ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(City City, int traitId)
        {
            _db.Cities.Add(City);
            _db.SaveChanges();
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
            var thisCity = _db.Cities.FirstOrDefault(Cities => Cities.CityId == id);
            ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
            return View(thisCity);
        }

        [HttpPost]
        public ActionResult Edit(City City, int TraitId)
        {
            _db.Entry(City).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // [Authorize]
        // public ActionResult AddTrait(int id)
        // {
        //     var thisCity = _db.Cities.FirstOrDefault(City => City.CityId == id);
        //     ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
        //     return View(thisCity);
        // }

        // [Authorize]
        // [HttpPost]
        // public ActionResult AddTrait(City City, int TraitId)
        // {

        //     if (TraitId != 0)
        //     {
        //         var compareCitytrait = _db.CityCities.FirstOrDefault(trait => trait.TraitId == TraitId);
        //         foreach (CityTrait compareTrait in City.Cities)
        //         {
        //             if (City.CityId == compareCitytrait.CityId)
        //             {
        //                 if (compareCitytrait.TraitId == TraitId)
        //                 {

        //                     return RedirectToAction("Index", "Cities");
        //                 }
        //             }
        //         }
        //         _db.CityCities.Add(new CityTrait() { TraitId = TraitId, CityId = City.CityId });
        //         _db.SaveChanges();

        //     }
        //     return RedirectToAction("Index", "Cities");
        // }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(Cities => Cities.CityId == id);
            return View(thisCity);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisCity = _db.Cities.FirstOrDefault(Cities => Cities.CityId == id);
            _db.Cities.Remove(thisCity);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // [Authorize]
        // [HttpPost]
        // public ActionResult DeleteTrait(int joinId)
        // {
        //     var joinEntry = _db.CityCities.FirstOrDefault(entry => entry.CityTraitId == joinId);
        //     _db.CityCities.Remove(joinEntry);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}