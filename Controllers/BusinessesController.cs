using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using LocalLookupMVC.Models;

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

        public IActionResult Index(int page = 1, int pageCount = 2)
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
            ViewBag.CityId = new SelectList(_db.Cities, "CityId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Business Business, int cityId)
        {
            _db.Businesses.Add(Business);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisBusiness = _db.Businesses;
            return View(thisBusiness);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisBusiness = _db.Businesses.FirstOrDefault(Businesses => Businesses.BusinessId == id);
            ViewBag.CityId = new SelectList(_db.Cities, "CityId", "Name");
            return View(thisBusiness);
        }

        [HttpPost]
        public ActionResult Edit(Business Business, int CityId)
        {

            _db.Entry(Business).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            var thisBusiness = _db.Businesses.FirstOrDefault(Businesses => Businesses.BusinessId == id);
            return View(thisBusiness);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var thisBusiness = _db.Businesses.FirstOrDefault(Businesses => Businesses.BusinessId == id);
            _db.Businesses.Remove(thisBusiness);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}