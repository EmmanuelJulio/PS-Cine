using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    public class FuncionesDTO
    {
        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
       
    }
}
