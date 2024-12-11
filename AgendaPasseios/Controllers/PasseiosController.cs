using AgendaPasseios.Data;
using AgendaPasseios.Models;
using AgendaPasseios.Services;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPasseios.Controllers
{
    public class PasseiosController : Controller
    {
        private readonly PasseioService _service;

        public PasseiosController(PasseioService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            List<Passeio> passeios = _service.FindAll();
            return View(passeios);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Passeio passeio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _service.Insert(passeio);

            return RedirectToAction(nameof(Index));

        }

    }
}
