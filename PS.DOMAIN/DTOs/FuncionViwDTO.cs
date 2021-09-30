using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    public class FuncionViwDTO
    {
        public int funcionId { get; set; }
        public string PeliculaNombre { get; set; }
        public int SalaId { get; set; }
        public string Fecha { get; set; }
        public string Horario { get; set; }
    }
}
