using PS.APLICATION.Services;
using PS.DATE;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Validations
{
    public interface IFuncionValidation
    {
        public bool CrearFuncion(int idpelicula, TimeSpan horaFuncion, int salaid);
        public int VerificarCapacidadDelaFuncion(int salaid, int funcionid);
    }



    public class FuncionValidation : IFuncionValidation
    {

        private readonly FuncionService service;
        private readonly ApplicationDbContext context;

        public FuncionValidation(FuncionService service, ApplicationDbContext context)
        {
            this.service = service;
            this.context = context;
        }

        public bool CrearFuncion(int idpelicula, TimeSpan horaFuncion, int salaid)
        {

            if (!service.VerificarHorarioSala(horaFuncion, salaid))
            {
                service.AddFunction(new Funciones { Fecha = DateTime.Now, PeliculaId = idpelicula, SalaId = salaid, Horario = horaFuncion });                               
                Console.WriteLine("se agrego la funcion");
                return true;
            }
            else
                Console.WriteLine("ya existe una funcion a esa hora en esa sala");
            return false;
            
        }

        public int VerificarCapacidadDelaFuncion(int salaid, int funcionid)
        {
            return (from x in context.Tickets where x.FuncionId == funcionid select x).Count();                        
        }
    }
}
