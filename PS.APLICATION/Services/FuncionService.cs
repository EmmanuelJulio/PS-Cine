using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;
using PS.DOMAIN.DTOs;
using PS.DOMAIN.Entities;
using PS.DOMAIN.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.APLICATION.Services
{

    public interface IFuncionService
    {
 
        public FuncionesDTO AddFunctionAndReturn(FuncionesDTO entity);
        public Funciones OptenerFuncionPorId(int idfuncion);

        public List<Funciones> FuncionesDisponibles(int Film);

        public List<Funciones> FuncionesDisponiblesEnSala(int idSala);

        public bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha);
        public List<Funciones> OptenerTodasLasFunciones();
        object Delete(int id);
        List<FuncionViwDTO> OptenerTodasLasFuncionesDTO();
       string OptenerNombreDePelicula(int id);
        List<FuncionesDTO> GetFuncionesDePelicula(int id);
    }


    public class FuncionService: IFuncionService
    {
        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly IFuncionQuery _query;

        public FuncionService(IGenericsRepository genericsRepository, ApplicationDbContext context, IFuncionQuery query)
        {
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
        }


        public FuncionesDTO AddFunctionAndReturn(FuncionesDTO entity)
        {
            DateTime fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null);
            if (!VerificarHorarioSala(Convert.ToDateTime(entity.Horario).TimeOfDay,entity.SalaId, fecha))
            {
                var NewFuncion = new Funciones()
                {
                    PeliculaId = entity.PeliculaId,
                    Fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null),
                  Horario =Convert.ToDateTime(entity.Horario).TimeOfDay,
                    SalaId = entity.SalaId
                };

                genericsRepository.Add<Funciones>(NewFuncion);
                return entity;

            }
            return null;

        }

        public object Delete(int id)
        {
            var Funcion = (from x in context.Funciones where x.FuncionId == id select x).FirstOrDefault<Funciones>();
            if (Funcion != null)
            {
                genericsRepository.Delete<Funciones>(Funcion);
                return Funcion;
            }
            else 
            {
                return Funcion;
            }
            

        }

        public List<Funciones> FuncionesDisponibles(int Film)
        {
                       
            return (from x in context.Funciones where x.PeliculaId == Film select x).ToList();
        }

        public List<Funciones> FuncionesDisponiblesEnSala(int idSala)
        {
            return (from x in context.Funciones where x.SalaId == idSala select x).ToList();
        }

        public List<FuncionesDTO> GetFuncionesDePelicula(int id)
        {
            return _query.GuetFuncionesByIdFilm(id);
        }

        public Funciones OptenerFuncionPorId(int idfuncion)
        {
            
           return (from x in context.Funciones where x.FuncionId == idfuncion select x).FirstOrDefault<Funciones>();
            
        }

        public string OptenerNombreDePelicula(int id)
        {
            string nombrePelicula = (from x in context.Peliculas where x.PeliculaId == id select x.Titulo).FirstOrDefault<string>();
            return nombrePelicula;
        }

        public List<Funciones> OptenerTodasLasFunciones()
        {
            return (from x in context.Funciones select x).ToList();
        }

        public List<FuncionViwDTO> OptenerTodasLasFuncionesDTO()
        {
            List<FuncionViwDTO> Funciones = new List<FuncionViwDTO>();
            var funciones = (from x in context.Funciones select x).ToList();
            foreach(Funciones funcion in funciones)
            {
                FuncionViwDTO _funcion = new FuncionViwDTO
                {
                    funcionId=funcion.FuncionId,
                    PeliculaId = funcion.PeliculaId,
                    PeliculaNombre = OptenerNombreDePelicula(funcion.PeliculaId),
                    SalaId = funcion.SalaId,
                    Fecha = funcion.Fecha.ToString("dd-MM-yyyy"),
                    Horario = funcion.Horario.ToString(),
                };
                Funciones.Add(_funcion);
            }
            return Funciones;
        }


        public bool VerificarHorarioSala(TimeSpan horario, int idsala,DateTime fecha)
        {
            TimeSpan horasDeFuncionStandar =DateTime.Parse("2:30:00").TimeOfDay;
            bool yaExisteUnaFuncionEnEsaHora = false;       
                List<Funciones> funcion = (from x in context.Funciones where x.SalaId == idsala & x.Fecha==fecha select x).ToList();
            if (funcion.Any())
                {
                    foreach (Funciones funciones in funcion)
                    {
                        if (Convert.ToDateTime(funciones.Horario).TimeOfDay + horasDeFuncionStandar > horario)
                            return yaExisteUnaFuncionEnEsaHora = true;
                    }
                }       
            return yaExisteUnaFuncionEnEsaHora;
        }
    }
}
