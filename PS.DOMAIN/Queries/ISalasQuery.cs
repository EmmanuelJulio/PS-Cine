using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Queries
{
    public interface ISalasQuery
    {
        int PuestosRestantesEnFuncion(int idsala, int funcionId);
        bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha);
        bool VerificarHorarioSala(int idSala);
    }
}
