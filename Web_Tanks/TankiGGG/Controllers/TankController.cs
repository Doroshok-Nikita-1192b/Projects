using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TankiGGG.Models;
using TankiGGG.Models.ViewModels;

namespace TankiGGG.Controllers
{
    public class TankController : Controller
    {
        public readonly DataDbContext _db;

        public TankController(DataDbContext db)
        {
            _db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Tank> objList = _db.Tanks;

            foreach (var obj in objList)
            {
                obj.TankType = _db.tankTypes.FirstOrDefault(u => u.Id == obj.Tank_type_id);
                obj.Nation = _db.Nations.FirstOrDefault(u => u.Id == obj.Tank_type_id);

            }

            return View(objList);
        }

        // GET-Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            TankVM tankVM = new TankVM()
            {
                Tank = new Tank(),
                TDDNation = _db.Nations.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TDDTank_type = _db.tankTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            return View(tankVM);
        }

        // POST-Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult Create(TankVM obj)
        {
            if (ModelState.IsValid)
            {
                //obj.ExpenseTypeId = 1;
                _db.Tanks.Add(obj.Tank);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        // GET Delete
        [Authorize(Roles = "admin")]
        public IActionResult Delete(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Tanks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }

        // POST Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Tanks.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Tanks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET Update
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(int? id)
        {
            TankVM tankVM = new TankVM()
            {
                Tank = new Tank(),
                TDDNation = _db.Nations.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                TDDTank_type = _db.tankTypes.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return NotFound();
            }
            tankVM.Tank = _db.Tanks.Find(id);
            if (tankVM.Tank == null)
            {
                return NotFound();
            }
            return View(tankVM);

        }

        // POST UPDATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin, moderator")]
        public IActionResult Update(TankVM obj)
        {
            if (ModelState.IsValid)
            {
                _db.Tanks.Update(obj.Tank);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tank = await _db.Tanks.Include(b => b.Nation).Include(c => c.TankType)
            .FirstOrDefaultAsync(m => m.Id == id);

            if (tank == null)
            {
                return NotFound();
            }

            return View(tank);

        }
    }
}
