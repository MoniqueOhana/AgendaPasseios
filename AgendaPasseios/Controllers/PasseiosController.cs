using AgendaPasseios.Data;
using AgendaPasseios.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPasseios.Controllers
{
    public class PasseiosController : Controller
    {
        private readonly AgendaPasseiosContext _context;

        public PasseiosController(AgendaPasseiosContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Passeio> passeios = _context.Passeios.ToList();
            return View(passeios);
        }
    }
}
