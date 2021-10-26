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
       
        public int VerificarCapacidadDelaFuncion(int salaid, int funcionid);
        public bool ValidarFuncion(int idFuncion);
        public bool ValidateParametersRequest(string fecha, string titulo);
       
    }



    public class FuncionValidation : IFuncionValidation
    {
        
        private readonly ApplicationDbContext context;

        public FuncionValidation(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool ValidarFuncion(int idFuncion)
        {
            
                Funciones funcion = (from x in context.Funciones where x.FuncionId == idFuncion select x).FirstOrDefault<Funciones>();
                if (funcion != null)
                    return true;
                else
                    return false;
            
        }

        public bool ValidateParametersRequest(string fecha, string titulo)
        {
            if (string.IsNullOrEmpty(fecha) && string.IsNullOrEmpty(titulo))
                return false;

            return true;                      
        }

       

        public int VerificarCapacidadDelaFuncion(int salaid, int funcionid)
        {
            return (from x in context.Tickets where x.FuncionId == funcionid select x).Count();                        
        }

      
    }
}
