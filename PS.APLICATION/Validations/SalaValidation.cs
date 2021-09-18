using PS.DATE;
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
    }
}
