using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.Model;

namespace Web.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomService roomService = new RoomService();
        private readonly IReservationService reservationService = new ReservationService();
        
        [HttpGet]
        public ActionResult Index(RoomSearch search)
        {
            var rooms = new List<room>();
            if (search.Start != null && search.End != null)
            {
                rooms.AddRange(roomService.FindAvailable(search.Start, search.End));
            } else
            {
                rooms.AddRange(roomService.GetAll());
            }

            if (search.Beds != 0)
            {
                rooms = rooms.FindAll(t => t.beds == search.Beds);
            }
            if (!string.IsNullOrEmpty(search.Quality))
            {
                rooms = rooms.FindAll(room => room.quality == search.Quality);
            }


            var model = new RoomSearchIndexModel
            {
                Results = rooms,
            };

            return View(model);
        }
    }
}
