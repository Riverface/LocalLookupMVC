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
        [Authorize]
        public IActionResult Index(int page = 1, int pageCount = 2)
        {
            IQueryable<Object> bizQuery = Business.GetBusinesses().AsQueryable();
            if(page <= 0 ){
               page = 1;
            }
            ViewBag.pageCount = pageCount;
            bizQuery = PaginationHelper.GetPaged(bizQuery, page, pageCount);
            List<Business> results = bizQuery.Cast<Business>().ToList();
            ViewBag.page = page;
            if(results.Count == 0){
                return View();
            }
            else{

            return View(results);
            }
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Business Business, int traitId)
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
            ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
            return View(thisBusiness);
        }

        [HttpPost]
        public ActionResult Edit(Business Business, int TraitId)
        {
            _db.Entry(Business).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // [Authorize]
        // public ActionResult AddTrait(int id)
        // {
        //     var thisBusiness = _db.Businesses.FirstOrDefault(Business => Business.BusinessId == id);
        //     ViewBag.TraitId = new SelectList(_db.Cities, "TraitId", "Name");
        //     return View(thisBusiness);
        // }

        // [Authorize]
        // [HttpPost]
        // public ActionResult AddTrait(Business Business, int TraitId)
        // {

        //     if (TraitId != 0)
        //     {
        //         var compareBusinesstrait = _db.BusinessCities.FirstOrDefault(trait => trait.TraitId == TraitId);
        //         foreach (BusinessTrait compareTrait in Business.Cities)
        //         {
        //             if (Business.BusinessId == compareBusinesstrait.BusinessId)
        //             {
        //                 if (compareBusinesstrait.TraitId == TraitId)
        //                 {

        //                     return RedirectToAction("Index", "Businesses");
        //                 }
        //             }
        //         }
        //         _db.BusinessCities.Add(new BusinessTrait() { TraitId = TraitId, BusinessId = Business.BusinessId });
        //         _db.SaveChanges();

        //     }
        //     return RedirectToAction("Index", "Businesses");
        // }

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

        // [Authorize]
        // [HttpPost]
        // public ActionResult DeleteTrait(int joinId)
        // {
        //     var joinEntry = _db.BusinessCities.FirstOrDefault(entry => entry.BusinessTraitId == joinId);
        //     _db.BusinessCities.Remove(joinEntry);
        //     _db.SaveChanges();
        //     return RedirectToAction("Index");
        // }
    }
}