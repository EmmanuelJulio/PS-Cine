using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.DTOs
{
    public class TicketDTO

    {
        
        public int funcionId { get; set; }
        [Required(ErrorMessage = "Debe ingresar un Usuario")]
        public string usuario { get; set; }
        [Required(ErrorMessage = "Debe ingresar una cantidad")]
        public int cantidad { get; set; }
    }
}
