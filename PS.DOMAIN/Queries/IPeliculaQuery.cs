using PS.DOMAIN.DTOs;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Queries
{
    public interface IPeliculaQuery
    {
        

        object GetPeliculas();
        object GetPeliculasCompleta();
        object GetPeliculaDTO(int id);
        FuncionViwDTO getFilmByIdFuntion(int id);
    }
}
