using LocalLookupMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace LocalLookupMVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : Controller
    {
        private LocalLookupMVCContext _db;

        public CitiesController(LocalLookupMVCContext db)
        {
            _db = db;
        }

        // GET api/Cities
        [HttpGet]
        public ActionResult<IEnumerable<City>> Get(string name, int id, string bio, string faction, int minLevel, int maxLevel, int minMight, int maxMight, int minSpryness, int maxSpryness, int minJudgement, int maxJudgement, int minEcho, int maxEcho, int minMagnetism, int maxMagnetism, int minFortune, int maxFortune)
        {
            var query = _db.Cities.AsQueryable();

            return query.ToList();
        }

        // GET api/Cities/{id}
        [HttpGet("{id}")]
        public ActionResult<City> Get(int id)
        {
            return _db.Cities.FirstOrDefault(entry => entry.CityId == id);
        }

        // POST api/Cities
        [HttpPost /*, ActionName("PostSingle") */ ]
        public void Post([FromBody] City City)
        {
            _db.Cities.Add(City);
            _db.SaveChanges();
        }

        // [HttpPost, ActionName("PostArray")]
        // public void Post([FromBody] City[] Cities)
        // {
        //     foreach (City City in Cities)
        //     {
        //         _db.Cities.Add(City);
        //     }
        //     _db.SaveChanges();
        // }

        //PUT api/Cities/{id}
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] City City)
        {
            City.CityId = id;
            _db.Entry(City).State = EntityState.Modified;
            _db.SaveChanges();
        }

        //DELETE api/Cities/{id}
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BusinessToDelete = _db.Cities.FirstOrDefault(entry => entry.CityId == id);
            _db.Cities.Remove(BusinessToDelete);
            _db.SaveChanges();
        }
    }
}