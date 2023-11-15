using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationHalper reservationHalper;
        private readonly IRoomHalper roomHalper;
        private readonly ICustomerHalper customerHalper;

        public ReservationController(IReservationHalper reservationHalper,IRoomHalper roomHalper,ICustomerHalper customerHalper)
        {
            this.reservationHalper = reservationHalper;
            this.roomHalper = roomHalper;
            this.customerHalper = customerHalper;
        }
        // GET: ReservationController
        public async Task<IActionResult> Index()
        {
            var lst = await reservationHalper.GetAll();
            return View(lst);
        }

        // GET: ReservationController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        // GET: ReservationController/Create
        public async Task<IActionResult> Add()
        {
            ViewBag.Rooms = new SelectList( await roomHalper.GetAll(),"Id","Name");
            ViewBag.Customers = new SelectList(await customerHalper.GetAll());
            return View();
        }

        // POST: ReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Reservation reservation)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            return View();
        }

        // POST: ReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ReservationController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            return View();
        }

        // POST: ReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
