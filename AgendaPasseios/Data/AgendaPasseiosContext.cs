using AgendaPasseios.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaPasseios.Data
{
    public class AgendaPasseiosContext : DbContext
    {
        public AgendaPasseiosContext(DbContextOptions<AgendaPasseiosContext> options) : base(options)
        {

        }

        public DbSet<Passeio> Passeios {  get; set; }
    }
}
