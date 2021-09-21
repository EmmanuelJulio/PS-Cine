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
    public interface ITicketService
    {
        void AddTicket(Tickets entity);
        public void AgregarTikets(Tickets tiket);
    }

    public class TicketService: ITicketService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;

        public TicketService(IGenericsRepository genericsRepository, ApplicationDbContext context)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
        }

        public void AddTicket(Tickets entity)
        {
            genericsRepository.Add<Tickets>(entity);
        }

        public void AgregarTikets(Tickets tiket)
        {
            tiket.TiketId = Guid.NewGuid();
            context.Add(tiket);
            context.SaveChanges();
        }
    }
}
