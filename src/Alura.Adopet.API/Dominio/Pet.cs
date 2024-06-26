using System.ComponentModel.DataAnnotations;

namespace Project.Adopet.API.Dominio
{
    public class Pet
    {
        public Pet()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public TipoPet Tipo { get; set; }        
    }
}
