using AgendaPasseios.Data;
using AgendaPasseios.Models;
using AgendaPasseios.Services;
using AgendaPasseios.Services.Exceptions;
using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaPasseios.Controllers
{
    public class PasseiosController : Controller
    {
        private readonly PasseioService _service;

        public PasseiosController(PasseioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.FindAllAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Passeio passeio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _service.InsertAsync(passeio);

            return RedirectToAction(nameof(Index));

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            Passeio passeio = await _service.FindByIdAsync(id.Value);
            if (passeio is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });

            }
            return View(passeio);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }
            
            public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            Passeio passeio = await _service.FindByIdAsync(id.Value);
            if (passeio is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }
            return View(passeio);
        }
        // POST Genres/Edit/x
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Passeio passeio)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (id != passeio.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id's não condizentes" });
            }

            try
            {
                await _service.UpdateAsync(passeio);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException ex)
            {
                return RedirectToAction(nameof(Error), new { message = ex.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }
            Passeio passeio = await _service.FindByIdAsync(id.Value);
            if (passeio is null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não encontrado" });
            }

            return View(passeio);
        }



        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
                
        }
    }
}
