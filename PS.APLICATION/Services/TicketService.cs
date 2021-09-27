using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;
using PS.DOMAIN.DTOs;
using PS.DOMAIN.Entities;
using PS.DOMAIN.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Services
{
    public interface ITicketService
    {
        object AddTiket(TicketDTO tiket);
    }

    public class TicketService: ITicketService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly ITiketsQuery _query;

        public TicketService(IGenericsRepository genericsRepository, ApplicationDbContext context, ITiketsQuery query)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
        }

        public object AddTiket(TicketDTO tiket)
        {
            int IdSala = (from x in context.Funciones where x.FuncionId == tiket.funcionId select x.SalaId).FirstOrDefault<int>();
            int capacidadDeSala = (from x in context.Salas where x.SalasId == IdSala select x.Capacidad).FirstOrDefault<int>();
            int TiketParaFuncion = (from x in context.Tickets where x.FuncionId == tiket.funcionId select x).Count();
            List<Tickets> ListaDeTickets = new List<Tickets>();
            if (capacidadDeSala- TiketParaFuncion > tiket.cantidad)
            {
                for (int i = 0;i < tiket.cantidad ; i++)
                {
                    Tickets tickets = new Tickets
                    {
                        TiketId = Guid.NewGuid(),
                        FuncionId = tiket.funcionId,
                        Usuario = tiket.usuario
                    };
                    genericsRepository.Add<Tickets>(tickets);
                    ListaDeTickets.Add(tickets);
                }
                return ListaDeTickets;
            }
            return null;
        }

    }
}
