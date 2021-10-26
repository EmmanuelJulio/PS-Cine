using PS.APLICATION.Validations;
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
        int GetTicketsRestantes(int funcionId);
    }

    public class TicketService: ITicketService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly ITiketsQuery _query;
        private readonly IFuncionValidation funcionValidation;

        public TicketService(IGenericsRepository genericsRepository, ApplicationDbContext context, ITiketsQuery query, IFuncionValidation funcionValidation)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
            this.funcionValidation = funcionValidation;
        }

        public object AddTiket(TicketDTO tiket)
        {

            if (funcionValidation.ValidarFuncion(tiket.funcionId))
            {
                List<TicketDTO> ListaDeTickets = new List<TicketDTO>();
                if (GetTicketsRestantes(tiket.funcionId) >=tiket.cantidad)
                {
                    for (int i = 0; i < tiket.cantidad; i++)
                    {
                        Tickets tickets = new Tickets
                        {
                            TiketId = Guid.NewGuid(),
                            FuncionId = tiket.funcionId,
                            Usuario = tiket.usuario
                        };
                        genericsRepository.Add<Tickets>(tickets);

                        ListaDeTickets.Add(new TicketDTO
                        {

                            funcionId = tiket.funcionId,
                            usuario = tiket.usuario,
                            cantidad = 1
                        });

                    }
                    return ListaDeTickets;
                }
                return "No existen tantos cupos para esa funcion"; 
            }
            else
            {
                return "No existe esa funcion";
            }
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
