namespace AgendaPasseios.Models
{
    public class Passeio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Destino { get; set; }
        public double Valor { get; set; }
        public string Empresa { get; set; }

        public Passeio()
        {

        }

        public Passeio(int id, string nome, string destino, double valor, string empresa)
        {
            Id = id;
            Nome = nome;
            Destino = destino;
            Valor = valor;
            Empresa = empresa;
        }
    }
}
