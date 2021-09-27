using PS.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Queries
{
    public interface IFuncionQuery
    {
        List<FuncionesDTO> GuetFuncionesByIdFilm(int id);
    }
}
