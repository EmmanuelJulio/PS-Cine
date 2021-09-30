using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Entities
{
    public class Peliculas
    {

        public int PeliculaId { get; set; }
        [StringLength(50)]
        public string Titulo { get; set; }
        [StringLength(255)]
        public string Poster { get; set; }
        [StringLength(255)]
        public string Sinospsis { get; set; }
        [StringLength(255)]
        public string Trailer { get; set; }
        public virtual ICollection<Funciones> Funciones { get; set; }

    }
}
