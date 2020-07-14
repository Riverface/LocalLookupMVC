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
            ViewBag.BusinessId = new SelectList(_db.Businesses, "BusinessId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Business business, int BusinessId)
        {
            Business.Post(business);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            Business thisBusiness = Business.GetDetails(id);
            return View(thisBusiness);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisBusiness = Business.GetDetails(id);
            ViewBag.CityId = new SelectList(Business.GetBusinesses(), "CityId", "Name");
            return View(thisBusiness);
        }

        [HttpPost]
        public ActionResult Edit(Business business, int CityId)
        {
            ViewBag.CityId = new SelectList(City.GetCities(), "CityId", "Name");
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
        public ActionResult DeleteConfirmed(int id)
        {
            Business.Delete(id);
            return RedirectToAction("Index");
        }


    }
}