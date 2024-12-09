using AgendaPasseios.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaPasseios.Controllers
{
    public class PasseiosController : Controller
    {
        public IActionResult Index()
        {
            List<Passeio> passeios = new List<Passeio>
            {
                new Passeio
                {
                    Id = 1,
                    Nome = "Passeio das águas",
                    Destino = "Natal",
                    Valor = 50.00,
                    Empresa = "Brisa e Mar Turismo"

                }

            }; 

            return View(passeios);
        }
    }
}
