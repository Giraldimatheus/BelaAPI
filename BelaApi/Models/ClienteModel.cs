using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BelaApi.Models
{
    public class ClienteModel
    {
        public ClienteModel()
        {

        }
        public ClienteModel(string nome, string cidade, string email, string telefone, string senha, DateTime dataNascimento)
        {
            Nome = nome;
            Cidade = cidade;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            DataNascimento = dataNascimento;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }

    }

}
