using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BelaApi.Models
{
    public class Telefone
    {
        public Telefone(int numero, string idContato)
        {
            Numero = numero;
            this.idContato = idContato;
        }

        [Key]
        [JsonIgnore]
        public int Id { get; set; }
        public int Numero { get; set; }
        public string idContato { get; set; }
    }
}
