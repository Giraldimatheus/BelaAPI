using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BelaApi.Models
{
    public class ContatoDoCliente
    {
        public ContatoDoCliente(string nome, string relacionamento, string email, string telefone, string emailClienteConexao)
        {
            Nome = nome;
            Relacionamento = relacionamento;
            Email = email;
            Telefone = telefone;
            EmailClienteConexao = emailClienteConexao;
        }
        public ContatoDoCliente()
        {

        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Relacionamento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string EmailClienteConexao { get; set; }
    }
}
