using System.ComponentModel.DataAnnotations;

namespace Project.Adopet.API.Dominio
{
    public class Cliente
    {
        public Cliente()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
    }
}
