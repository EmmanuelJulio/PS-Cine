using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Entities
{
    public class Funciones
    {

        public int FuncionId { get; set; }
        public int PeliculaId { get; set; }
        public int SalaId { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Horario { get; set; }
        public virtual ICollection<Tickets> Tickets { get; set; }
        public virtual Peliculas Peliculas { get; set; }
        public virtual Salas Salas { get; set; }



    }
}
