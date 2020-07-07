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

namespace Viewer.Controllers
{
    public class BusinessController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ViewerContext _db;

        public BusinessesController(UserManager<ApplicationUser> userManager, ViewerContext db)
        {
            _userManager = userManager;
            _db = db;
        }

        public IActionResult Index(int page = 1, int pageCount = 2)
        {
            IQueryable<Object> charQuery = Business.GetBusinesses().AsQueryable();
            if(page <= 0 ){
               page = 1;
            }
            ViewBag.pageCount = pageCount;
            charQuery = PaginationHelper.GetPaged(charQuery, page, pageCount);
            List<Business> results = charQuery.Cast<Business>().ToList();
            ViewBag.page = page;
            return View(results);
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.TraitId = new SelectList(_db.Traits, "TraitId", "Name");
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Create(Business Business, int traitId)
        {
            _db.Businesses.Add(Business);
            if (traitId != 0)
            {
                _db.BusinessTraits.Add(new BusinessTrait() { TraitId = traitId, BusinessId = Business.BusinessId });
            }
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var thisBusiness = _db.Businesses
                .Include(Business => Business.Traits)
                .ThenInclude(join => join.Trait)
                .FirstOrDefault(Business => Business.BusinessId == id);
            return View(thisBusiness);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var thisBusiness = _db.Businesses.FirstOrDefault(Businesses => Businesses.BusinessId == id);
            ViewBag.TraitId = new SelectList(_db.Traits, "TraitId", "Name");
            return View(thisBusiness);
        }

        [HttpPost]
        public ActionResult Edit(Business Business, int TraitId)
        {

            _db.Entry(Business).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult AddTrait(int id)
        {
            var thisBusiness = _db.Businesses.FirstOrDefault(Business => Business.BusinessId == id);
            ViewBag.TraitId = new SelectList(_db.Traits, "TraitId", "Name");
            return View(thisBusiness);
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

        [Authorize]
        [HttpPost]
        public ActionResult DeleteTrait(int joinId)
        {
            var joinEntry = _db.BusinessTraits.FirstOrDefault(entry => entry.BusinessTraitId == joinId);
            _db.BusinessTraits.Remove(joinEntry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}