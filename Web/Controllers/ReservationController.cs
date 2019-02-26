using Core.Services;
using System;
using System.Web.Mvc;
using Web.Model;

namespace Web.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IReservationService _reservationService;

        public ReservationController()
        {
            _reservationService = new ReservationService();
        }

        [HttpGet]
        public ActionResult Index()
        {
            var model = new ReservationIndexModel
            {
                Reservations = _reservationService.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public ActionResult Update()
        {
            throw new NotImplementedException();
        }
    }
}