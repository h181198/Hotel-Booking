using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Web.Helpers;
using Web.Model;

namespace Web.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly IReservationService reservationService = new ReservationService();
        private readonly IRoomService roomService = new RoomService();
        private readonly IUserService userService = new UserService();

        // GET: reservations
        public ActionResult Index(string email = "")
        {
            if (string.IsNullOrEmpty(email))
            {
                return View(new ReservationIndexModel { Reservations = new List<ReservationModel>() });
            }
            var user = userService.CreateIfAbsent(email);
            var reservations = reservationService.FindReservationUser(user.id);
            var reservationModel = ReservationHelper.ModelListTo(reservations);

            return View(reservationModel);
        }
        
        // GET: reservations/Create
        public ActionResult Create()
        {
            var rooms = roomService.GetAll();
            ViewBag.RoomId = new SelectList(rooms, "id", "id");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Start,End,Email,Beds,Quality")] ReservationModel res)
        {
            if (ModelState.IsValid)
            {
                var availableRooms = roomService.FindAvailable(res.Start, res.End);
                var vacant = availableRooms.Find(room => room.beds == res.Beds && room.quality.ToLower() == res.Quality.ToLower());

                var user = userService.CreateIfAbsent(res.Email);

                if (vacant != null)
                {
                    reservation reservation = reservationService.CreateReservation(res.Start, res.End, user.id, vacant.id);
                    reservationService.Add(reservation);

                    return RedirectToAction("Index");
                } else
                {
                    ViewBag.NotVacant = "No rooms that satisfy your needs are available at this moment.";
                }

            }
            
            return View(res);
        }
    }
}
