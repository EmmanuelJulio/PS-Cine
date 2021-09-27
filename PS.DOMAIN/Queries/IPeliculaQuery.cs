using PS.DOMAIN.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Queries
{
    public interface IPeliculaQuery
    {
        List<PeliculaDTO> GetPeliculas();
    }
}
