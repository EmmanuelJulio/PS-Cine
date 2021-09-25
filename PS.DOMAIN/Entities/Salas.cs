using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Entities
{
    public class Salas
    {

        public int SalasId { get; set; }
        public int Capacidad { get; set; }
        public virtual List<Funciones> Funciones { get; set; }

    }
}
