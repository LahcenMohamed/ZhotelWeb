using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZhotelWeb.Repositories.DataHalper;
using ZHotelWeb.Models;
using ZHotelWeb.Models.DTOs;

namespace ZhotelWeb.Site.Controllers
{
    [Authorize("User")]
    public class HomeUserController : Controller
    {
        private readonly IRoomHalper roomHalper;
        private readonly IReservationHalper reservationHalper;
        private readonly ICustomerHalper customerHalper;

        public HomeUserController(IRoomHalper roomHalper,IReservationHalper reservationHalper,ICustomerHalper customerHalper)
        {
            this.roomHalper = roomHalper;
            this.reservationHalper = reservationHalper;
            this.customerHalper = customerHalper;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> Rooms() 
        {
            var lst = await roomHalper.GetAll();
            return View(lst);
        }

        public async Task<IActionResult> BookRoom(int id)
        {
            RoomReservationVM roomReservationVM = new RoomReservationVM();
            roomReservationVM.Room = await roomHalper.GetById(id);
            return View(roomReservationVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookRoom(RoomReservationVM roomReservationVM)
        {

                Customer? customer = await customerHalper.GetByEmail(roomReservationVM.Email);
                if (customer != null)
                {
                Reservation reservation = new Reservation()
                {
                    DateOfArrival = roomReservationVM.Reservation.DateOfArrival,
                    DateOfDeparture = roomReservationVM.Reservation.DateOfDeparture,
                    CustomerId = customer.Id,
                    RoomId = roomReservationVM.Room.Id
                };
                await reservationHalper.Add(reservation);
                return RedirectToAction("Index");
                }
            return View(roomReservationVM);
        }
    }
}
