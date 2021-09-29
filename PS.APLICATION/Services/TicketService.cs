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
        
        List<TicketDTO> AddTiket(TicketDTO tiket);
        int GetTicketsRestantes(int funcionId);
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

        public List<TicketDTO> AddTiket(TicketDTO tiket)
        {

            List<TicketDTO> ListaDeTickets = new List<TicketDTO>();
            if (GetTicketsRestantes(tiket.funcionId) > tiket.cantidad)
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
                    TicketDTO ticketDTO = new TicketDTO
                    {
                        TiketId=tickets.TiketId,
                        funcionId = tiket.funcionId,
                        usuario = tiket.usuario,
                        cantidad = 1
                    };
                    ListaDeTickets.Add(ticketDTO);
                }
                return ListaDeTickets;
            }
            return null;
        }

        public int GetTicketsRestantes(int funcionId)
        {
            int IdSala = (from x in context.Funciones where x.FuncionId == funcionId select x.SalaId).FirstOrDefault<int>();
            int capacidadDeSala = (from x in context.Salas where x.SalasId == IdSala select x.Capacidad).FirstOrDefault<int>();
            int TiketParaFuncion = (from x in context.Tickets where x.FuncionId == funcionId select x).Count();
            return capacidadDeSala - TiketParaFuncion;
        }

        
    }
}
