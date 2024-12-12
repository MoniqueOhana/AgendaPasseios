using AgendaPasseios.Controllers;
using AgendaPasseios.Data;
using AgendaPasseios.Models;
using AgendaPasseios.Services.Exceptions;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace AgendaPasseios.Services
{
    public class PasseioService
    {
        private readonly AgendaPasseiosContext _context;

        public PasseioService(AgendaPasseiosContext context)
        {
            _context = context;
        }

        public async Task<List<Passeio>> FindAllAsync()
        {
            return await _context.Passeios.ToListAsync();
        }
        public async Task InsertAsync(Passeio passeio)
        {
            _context.Add(passeio);
            await _context.SaveChangesAsync();
        }

        public async Task<Passeio> FindByIdAsync(int id)
        {
            return await _context.Passeios.FindAsync(id);
        }

        public async Task RemoveAsync(int id)
        {
            try
            {
                Passeio passeio = await _context.Passeios.FindAsync(id);
                _context.Passeios.Remove(passeio);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                throw new IntegrityException(ex.Message);
            }
        }
        // POST: Genres/Edit/x
        public async Task UpdateAsync(Passeio passeio)
        {
            // Confere se tem alguém com esse Id
            bool hasAny = await _context.Passeios.AnyAsync(x => x.Id == passeio.Id);
            // Se não tiver, lança exceção de NotFound.
            if (!hasAny)
            {
                throw new NotFoundException("Id não encontrado");
            }
            // Tenta atualizar
            try
            {
                _context.Update(passeio);
                await _context.SaveChangesAsync();
            }
            // Se não der, captura a exceção lançada
            catch (DbUpdateConcurrencyException ex)
            {
                throw new DbConcurrencyException(ex.Message);
            }
        }
        
    }
}
