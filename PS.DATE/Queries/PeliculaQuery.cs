using PS.DOMAIN.DTOs;
using PS.DOMAIN.Queries;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Execution;
using PS.DOMAIN.Entities;

namespace PS.DATE.Queries
{
    
   public class PeliculaQuery : IPeliculaQuery
    {

        private readonly ApplicationDbContext context;


public PeliculaQuery(ApplicationDbContext context)
        {
            this.context = context;
        }

        public FuncionViwDTO getFilmByIdFuntion(int id)
        {
            return (from x in context.Funciones
                    join peliculas in context.Peliculas on x.PeliculaId equals peliculas.PeliculaId
                    where x.FuncionId == id
                    select new FuncionViwDTO { funcionId = x.FuncionId,
                        PeliculaNombre = peliculas.Titulo,poster=peliculas.Poster,
                        sinopsis=peliculas.Sinopsis, SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(),
                        Horario = x.Horario.ToString(@"hh\:mm") }).FirstOrDefault<FuncionViwDTO>();
        }

        public object GetPeliculaDTO(int id)
        {
            return (from x in context.Peliculas where x.PeliculaId == id
                    select new PeliculaDTO
                    {
                        titulo = x.Titulo,
                        poster = x.Poster,
                        trailer = x.Trailer,
                        sinopsis = x.Sinopsis
                    }).FirstOrDefault<PeliculaDTO>();
        }

        public object GetPeliculas()
        {
            
            return  (from x in context.Peliculas 
                             select new PeliculaDTO{titulo = x.Titulo,poster=x.Poster,
                                 trailer=x.Trailer,sinopsis=x.Sinopsis }).ToList<PeliculaDTO>();
            
            
        }

        public object GetPeliculasCompleta()
        {
            
            return (from x in context.Peliculas 
                             select new PeliculaDtoSinFunc { 
                                 PeliculaId = x.PeliculaId, Titulo = x.Titulo,
                                 Poster = x.Poster, Sinopsis = x.Sinopsis, 
                                 Trailer = x.Trailer }).ToList<PeliculaDtoSinFunc>();
            
            

        }


    }
}
