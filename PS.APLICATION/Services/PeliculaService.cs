using Newtonsoft.Json;
using PS.APLICATION.Validations;
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
        public object MostrarPeliculas();
        public ResponseDTO<object> GetFilm(int id);
        public object UpdatePelicula(PeliculaDTO pelicula, int id);
        public object GetAllFilm();
    }


    public class PeliculaService: IpeliculaService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly IPeliculaQuery _query;
        private readonly IPeliculaValidation peliculaValidator;

        public PeliculaService(IGenericsRepository genericsRepository, ApplicationDbContext context, IPeliculaQuery query, IPeliculaValidation peliculaValidator)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
            this.peliculaValidator = peliculaValidator;
        }

        public object GetAllFilm()
        {
            return _query.GetPeliculasCompleta();
        }

        public ResponseDTO<object> GetFilm(int id)
        {
            ResponseDTO<object> response = new ResponseDTO<object>();
            if (peliculaValidator.ValidarPkPelicula(id))
            {

                response.Data.Add(_query.GetPeliculaDTO(id));
                return response;
                  
            }
            response.Response.Add("No existe esa pelicula en nuestras bases de datos");
            return response;
        }

       

        public object MostrarPeliculas()
        {
            return _query.GetPeliculas();

        }

      

      

        public object UpdatePelicula(PeliculaDTO pelicula, int id)
        {
            ResponseDTO<PeliculaDTO> response = new ResponseDTO<PeliculaDTO>();
            if (peliculaValidator.ValidarPkPelicula(id))
            {
                Peliculas NuevaPelicula = new Peliculas()
                {
                    PeliculaId = id,
                    Titulo = pelicula.titulo,
                    Sinopsis = pelicula.sinopsis,
                    Trailer = pelicula.trailer,
                    Poster = pelicula.poster

                };
                genericsRepository.Update<Peliculas>(NuevaPelicula);
               response.Data.Add(pelicula);

                return response.Data;
            }
            else {
                response.Response.Add("No existe el identificador de esa pelicula");
                return response.Response;
            }

            
        }
    }
}
