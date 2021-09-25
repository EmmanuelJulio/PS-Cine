using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    class PeliculaDTO
    {
        public int PeliculaId { get; set; }
      
        public string Titulo { get; set; }
       
        public string Poster { get; set; }
     
        public string Sinospsis { get; set; }
       
        public string Trailer { get; set; }
    }
}
