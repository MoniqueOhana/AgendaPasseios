using AgendaPasseios.Data;
using AgendaPasseios.Models;
using Humanizer.Localisation;

namespace AgendaPasseios.Services
{
    public class PasseioService
    {
        private readonly AgendaPasseiosContext _context;

        public PasseioService(AgendaPasseiosContext context)
        {
            _context = context;
        }

        public List<Passeio> FindAll()
        {
            return _context.Passeios.ToList();
        }
        public void Insert(Passeio passeio)
        {
            _context.Add(passeio);
            _context.SaveChanges();
        }

    }
}
