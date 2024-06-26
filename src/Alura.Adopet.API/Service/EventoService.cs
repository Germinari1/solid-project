using Project.Adopet.API.Dados.Context;
using Project.Adopet.API.Dominio;

namespace Project.Adopet.API.Service
{
    internal class EventoService : IEventoService
    {
        private DataBaseContext _context;
        public EventoService(DataBaseContext context)
        {
            _context = context;
        }

        public void GenerateFakeDate()
        {
            var proprietario = new Cliente()
            {
                CPF = "111.111.111-22",
                Name = "André",
                Email = "andre@email.com"
            };
            _context.Add(proprietario);
            var pet = new Pet()
            {
                Nome = "Sábio",
                Tipo = TipoPet.Gato,                
            };
            _context.Add(pet);
            _context.SaveChanges();
           
        }
    }
}
