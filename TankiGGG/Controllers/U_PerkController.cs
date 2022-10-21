using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankiGGG.Models;

namespace TankiGGG.Controllers
{
    public class U_PerkController : Controller
    {
        private readonly DataDbContext _db;

        public U_PerkController(DataDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "admin, moderator, user")]
        public IActionResult Index()
        {
            IEnumerable<U_Perk> objList = _db.U_Perks;
            return View(objList);
        }

        //get-request?
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }


        //post-request??
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(U_Perk obj)
        {
            if (ModelState.IsValid)
            {
                _db.U_Perks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.U_Perks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.U_Perks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.U_Perks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Update(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.U_Perks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin , moderator")]
        public IActionResult Update(U_Perk obj)
        {
            if (ModelState.IsValid)
            {
                _db.U_Perks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }


    }
}
