using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Services
{
    public interface ISalaService
    {
        public List<Salas> MostrarSalas();
        public int capacidadDeSala(int salaid);
    }

    public class SalaService: ISalaService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;

        public SalaService(IGenericsRepository genericsRepository, ApplicationDbContext context)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
        }

        public int capacidadDeSala(int salaid)
        {
            return (from x in context.Salas where x.SalasId == salaid select x.Capacidad).FirstOrDefault<int>();
             
        }

        public List<Salas> MostrarSalas()
        {
            return (from x in context.Salas select x).ToList();
        }
    }
}
