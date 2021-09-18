using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Entities
{
    public class Tickets
    {
        public Guid TiketId { get; set; }

        public int FuncionId { get; set; }
        [StringLength(50)]
        public string Usuario { get; set; }
        public virtual Funciones Funciones { get; set; }
    }
}
