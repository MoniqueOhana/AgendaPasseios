using AgendaPasseios.Controllers;
using AgendaPasseios.Data;
using AgendaPasseios.Models;
using AgendaPasseios.Services.Exceptions;
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
    }
}
