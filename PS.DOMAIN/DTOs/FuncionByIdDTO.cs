using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    public class FuncionByIdDTO
    {
        public int funcionId { get; set; }
        public string PeliculaNombre { get; set; }
        public string poster { get; set; }
        public string sinopsis { get; set; }
        public int SalaId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
        public string video { get; set; }
    }
}
