using PS.DATE;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Validations
{
    public interface IPeliculaValidation
    {
        public bool ValidarPkPelicula(int peliculaId);
    }
    public class PeliculaValidation : IPeliculaValidation
    {
        private readonly ApplicationDbContext context;

        public PeliculaValidation(ApplicationDbContext context)
        {
            this.context = context;
        }
        public bool ValidarPkPelicula(int peliculaId)
        {
            Peliculas pelicula = (from x in context.Peliculas where x.PeliculaId == peliculaId select x).FirstOrDefault<Peliculas>();
            if (pelicula != null)
                return true;
            else
                return false;
        }
    }
}
