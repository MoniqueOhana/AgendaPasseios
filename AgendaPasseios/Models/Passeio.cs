
using System.ComponentModel.DataAnnotations;

namespace AgendaPasseios.Models
{
    public class Passeio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")] 
        public string Destino { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
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
