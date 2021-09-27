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
        [Required(ErrorMessage = "Debe ingresar la funcion id")]
        public int funcionId { get; set; }
        public string usuario { get; set; }
        public int cantidad { get; set; }
    }
}
