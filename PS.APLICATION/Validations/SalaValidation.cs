using PS.DATE;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Validations
{
    public interface ISalaValidation
    {
        public int PuestosRestantesEnSala(int idsala, int funcionId);
        public bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha);
    }


    public class SalaValidation: ISalaValidation
    {
        private readonly ApplicationDbContext context;

        public SalaValidation(ApplicationDbContext context)
        {
            this.context = context;
        }

        public int PuestosRestantesEnSala(int idsala, int funcionId)
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
    }
}
