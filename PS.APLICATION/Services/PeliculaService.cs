using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;
using PS.DOMAIN.Entities;
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
        public List<PeliculaDTO> MasInformacionDeFilm(int idfilm);
        public string NombrePeliculaPorId(int idfilm);
        public PeliculaDTO GetFilm(int id);
    }


    public class PeliculaService: IpeliculaService
    {

        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;

        public PeliculaService(IGenericsRepository genericsRepository, ApplicationDbContext context)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
        }

        public PeliculaDTO GetFilm(int id)
        {
            return (from x in context.Peliculas where x.PeliculaId == id select x).FirstOrDefault<PeliculaDTO>();
        }

        public List<PeliculaDTO> MasInformacionDeFilm(int idfilm)
        {
            return (from x in context.Peliculas where x.PeliculaId == idfilm select x).ToList();
             
        }

        public List<PeliculaDTO> MostrarPeliculas()
        {
            return (from x in context.Peliculas select x).ToList();
            
        }

        public string NombrePeliculaPorId(int idfilm)
        {
            return (from x in context.Peliculas where x.PeliculaId == idfilm select x.Titulo).FirstOrDefault<string>(); ;
        }
    }
}
