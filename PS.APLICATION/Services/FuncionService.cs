using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Services
{

    public interface IFuncionService
    {
        public void AddFunction(Funciones entity);
        public Funciones AddFunctionAndReturn(Funciones entity);
        public Funciones OptenerFuncionPorId(int idfuncion);

        public List<Funciones> FuncionesDisponibles(int Film);

        public List<Funciones> FuncionesDisponiblesEnSala(int idSala);

        public bool VerificarHorarioSala(TimeSpan horario, int idsala);
        public List<Funciones> OptenerTodasLasFunciones();
    }


    public class FuncionService: IFuncionService
    {
        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        //private readonly iFuncion


        public FuncionService(IGenericsRepository genericsRepository, ApplicationDbContext context)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
        }

        public void AddFunction(Funciones entity)
        {
            genericsRepository.Add<Funciones>(entity);
        }

        public Funciones AddFunctionAndReturn(Funciones entity)
        {
            genericsRepository.Add<Funciones>(entity);
            return entity;
        }

        public List<Funciones> FuncionesDisponibles(int Film)
        {
                       
            return (from x in context.Funciones where x.PeliculaId == Film select x).ToList();
        }

        public List<Funciones> FuncionesDisponiblesEnSala(int idSala)
        {
            return (from x in context.Funciones where x.SalaId == idSala select x).ToList();
        }

        public Funciones OptenerFuncionPorId(int idfuncion)
        {
            
           return (from x in context.Funciones where x.FuncionId == idfuncion select x).FirstOrDefault<Funciones>();
            
        }

        public List<Funciones> OptenerTodasLasFunciones()
        {
            return (from x in context.Funciones select x).ToList();
        }

        public bool VerificarHorarioSala(TimeSpan horario, int idsala)
        {
            TimeSpan horasDeFuncionStandar = new TimeSpan(0, 2, 30, 0);
            bool yaExisteUnaFuncionEnEsaHora = false;       
                List<Funciones> funcion = (from x in context.Funciones where x.SalaId == idsala select x).ToList();
                if (funcion.Any())
                {
                    foreach (Funciones funciones in funcion)
                    {
                        if (funciones.Horario + horasDeFuncionStandar > horario)
                            return yaExisteUnaFuncionEnEsaHora = true;
                    }
                }       
            return yaExisteUnaFuncionEnEsaHora;
        }
    }
}
