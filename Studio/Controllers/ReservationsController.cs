using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.Models;

namespace Studio.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly StudioDbContext _db;
        
        public ReservationsController(StudioDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Reservation> r = _db.Reservations.ToList();
            return View(r);
        }
        public IActionResult NewReservation()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewReservation(Reservation rs)
        {
            if (ModelState.IsValid)
            {
                List<Reservation> l = _db.Reservations.ToList();
                
                if (l.Exists(m => m.Date.Equals(rs.Date)))
                {
                    ViewBag.message = "Taken date";
                    return View(rs);
                }

                _db.Reservations.Add(rs);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var reservation = await _db.Reservations.FirstOrDefaultAsync(u => u.Id == id);
            if (reservation == null)
            {
                return Json(new { success = false, message = "Error while Deleting" });
            }
            _db.Reservations.Remove(reservation);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful" });
        }

    }
}