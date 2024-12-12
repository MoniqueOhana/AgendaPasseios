using AgendaPasseios.Data;
using AgendaPasseios.Models;

namespace AgendaPasseios.Services
{
    public class SeedingService
    {
        private readonly AgendaPasseiosContext _context;
        public SeedingService(AgendaPasseiosContext context)
        {
            _context = context;
        }
        public async Task Seed()
        {
            if (_context.Passeios.Any()
            )
            {
                return;
            }

            Passeio p1 = new Passeio(1, "Passeio das Águas", "Natal", 50, "Brisa e Mar Turismo");
            Passeio p2 = new Passeio(2, "Passeio das tartarugas", "Ubatuba", 40, "Caiçara Turismo");
            Passeio p3 = new Passeio(3, "Rota das Baleias", "Litoral de Palhoça", 60, "Palhoça Tour");
            Passeio p4 = new Passeio(4, "Região dos Lagos", "Arraial do Cabo", 80, "Carioca Turismo");
            Passeio p5 = new Passeio(5, "Rota dos Fortes", "Florianópolis", 75, "Ilha da Magia Passeios");
            Passeio p6 = new Passeio(6, "Delta do Parnaíba", "Parnaíba", 70, "ParnaTour");
            Passeio p7 = new Passeio(7, "Luau na Ilha do Mel", "Ilha do Mel", 110, "Passeios do Mel");
            Passeio p8 = new Passeio(8, "Mergulho na Lagoa", "Florianópolis", 100, "AquaDive Floripa");
            Passeio p9 = new Passeio(9, "Buggie nas Dunas", "Natal", 230, "Brisa e Mar Turismo");
            Passeio p10 = new Passeio(10, "Luau no Rosa Norte", "Imbituba", 80, "Palhoça Tour");
        }
    }
}
