using PS.DATE;
using PS.DOMAIN.Entities;
using PS.DOMAIN.Queries;
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
        public bool VerificarExisteSala(int id);
    }


    public class SalaValidation: ISalaValidation
    {
        private readonly ApplicationDbContext context;
        private readonly ISalasQuery querry;

        public SalaValidation(ApplicationDbContext context, ISalasQuery querry)
        {
            this.context = context;
            this.querry = querry;
        }

        public int PuestosRestantesEnSala(int idsala, int funcionId)
        {

            return querry.PuestosRestantesEnFuncion(idsala, funcionId);
            
        }

        public bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha)
        {


            return querry.VerificarHorarioSala(horario, idsala, fecha);
            
        }
        public bool VerificarExisteSala(int id)
        {
            return querry.VerificarHorarioSala(id);
        }
    }
}
