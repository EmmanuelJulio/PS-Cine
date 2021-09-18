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
        public List<Peliculas> MostrarPeliculas();
        public List<Peliculas> MasInformacionDeFilm(int idfilm);
        public string NombrePeliculaPorId(int idfilm);
    }


    public class PeliculaService: IpeliculaService
    {

        private readonly GenericRepository genericsRepository;
        private readonly ApplicationDbContext context;

        public PeliculaService(GenericRepository genericsRepository, ApplicationDbContext context)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
        }

        public List<Peliculas> MasInformacionDeFilm(int idfilm)
        {
            return (from x in context.Peliculas where x.PeliculaId == idfilm select x).ToList();
             
        }

        public List<Peliculas> MostrarPeliculas()
        {
            return (from x in context.Peliculas select x).ToList();
            
        }

        public string NombrePeliculaPorId(int idfilm)
        {
            return (from x in context.Peliculas where x.PeliculaId == idfilm select x.Titulo).FirstOrDefault<string>(); ;
        }
    }
}
