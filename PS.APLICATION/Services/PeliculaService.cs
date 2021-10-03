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
    public interface IpeliculaService
    {
        public List<PeliculaDTO> MostrarPeliculas();
        public List<Peliculas> MasInformacionDeFilm(int idfilm);
      
        public Object GetFilm(int id);
        object UpdatePelicula(PeliculaDTO pelicula, int id);
    }


    public class PeliculaService: IpeliculaService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly IPeliculaQuery _query;

        public PeliculaService(IGenericsRepository genericsRepository, ApplicationDbContext context, IPeliculaQuery query)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
        }

        public object GetFilm(int id)
        {
            Peliculas Pelicula = (from x in context.Peliculas where x.PeliculaId == id select x).FirstOrDefault<Peliculas>();
            PeliculaDTO peliculaDTO = new PeliculaDTO
            {
                titulo = Pelicula.Titulo,
                poster = Pelicula.Poster,
                trailer = Pelicula.Trailer,
                sinospsis = Pelicula.Sinospsis
            };
            return peliculaDTO;
        }

        public List<Peliculas> MasInformacionDeFilm(int idfilm)
        {
            return (from x in context.Peliculas where x.PeliculaId == idfilm select x).ToList();
             
        }

        public List<PeliculaDTO> MostrarPeliculas()
        {
            return _query.GetPeliculas();

        }

      

      

        public object UpdatePelicula(PeliculaDTO pelicula, int id)
        {
            Peliculas NuevaPelicula = new Peliculas()
            {
                PeliculaId = id,
                Titulo = pelicula.titulo,
                Sinospsis = pelicula.sinospsis,
                Trailer = pelicula.trailer,
                Poster = pelicula.poster

            };
            genericsRepository.Update<Peliculas>(NuevaPelicula);
            return NuevaPelicula;
        }
    }
}
