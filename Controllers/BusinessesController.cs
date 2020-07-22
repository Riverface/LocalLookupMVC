using LocalLookupMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace LocalLookupMVC.Controllers
{
    public class BusinessesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly LocalLookupMVCContext _db;

        public BusinessesController(UserManager<ApplicationUser> userManager, LocalLookupMVCContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index(int page = 1, int pageCount = 5)
        {
            IQueryable<Object> bizQuery = Business.GetBusinesses().AsQueryable();
            if (page <= 0)
            {
                page = 1;
            }
            ViewBag.pageCount = pageCount;
            bizQuery = PaginationHelper.GetPaged(bizQuery, page, pageCount);
            List<Business> results = bizQuery.Cast<Business>().ToList();
            ViewBag.page = page;
            return View(results);
        }

        [Authorize]
        public ActionResult Create()
        {

            ViewBag.CityId = new SelectList(City.GetCities().AsEnumerable(), "CityId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Business business, int BusinessId)
        {
            await Business.Post(business);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Details(int id)
        {
            Business thisBusiness = Business.GetDetails(id);
            City tempCity = await City.GetDetails(thisBusiness.CityId); 
            
            if (tempCity.CityId != 0)
            {
                thisBusiness.City = await City.GetDetails(thisBusiness.CityId);
            }
            else
            {
                thisBusiness.CityId = 0;
            }
            await Business.Put(thisBusiness);
            return View(thisBusiness);
        }

        [Authorize]
        public async Task<ActionResult> Edit(int id)
        {
            Business thisBusiness = Business.GetDetails(id);
            if (thisBusiness.CityId != 0)
            {
                thisBusiness.City = await City.GetDetails(thisBusiness.CityId);
            }
            else
            {
                thisBusiness.City = new City();
            }
            ViewBag.CityId = new SelectList(City.GetCities().AsEnumerable(), "CityId", "Name");
            return View(thisBusiness);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Business business, int cityId)
        {
            business.CityId = cityId;
            await Business.Put(business);
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisBusiness = Business.GetDetails(id);
            return View(thisBusiness);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            await Business.Delete(id);
            return RedirectToAction("Index");
        }

    }
}