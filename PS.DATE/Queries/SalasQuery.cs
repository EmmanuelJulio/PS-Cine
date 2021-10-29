using PS.DOMAIN.Entities;
using PS.DOMAIN.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Queries
{
    public class SalasQuery : ISalasQuery
    {
        private readonly ApplicationDbContext context;

        public SalasQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int PuestosRestantesEnFuncion(int idsala, int funcionId)
        {
            int TiketsEmitidosEnFuncion = (from x in context.Tickets where x.FuncionId == funcionId select x).Count();
            int CapacidadDeLaFuncion = (from x in context.Salas where x.SalasId == idsala select x.Capacidad).FirstOrDefault<int>();
            return CapacidadDeLaFuncion - TiketsEmitidosEnFuncion;
        }

        public bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha)
        {
            TimeSpan horasDeFuncionStandar = DateTime.Parse("2:30:00").TimeOfDay;

            List<Funciones> funcion = (from x in context.Funciones where x.SalaId == idsala & x.Fecha == fecha select x).ToList();
            if (funcion.Any())
            {
                foreach (Funciones funciones in funcion)
                {

                    if (funciones.Horario + horasDeFuncionStandar > horario)
                        return true;
                }
            }
            return false;
        }

        public bool VerificarHorarioSala(int idSala)
        {
            var Sala = (from x in context.Salas where x.SalasId == idSala select x).FirstOrDefault<Salas>();
            if (object.ReferenceEquals(null, Sala))
                return false;
            else
                return true;
        }
    }
}
