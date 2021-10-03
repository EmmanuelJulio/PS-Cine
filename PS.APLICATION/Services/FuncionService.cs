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
        public int GetTicketsRestantes(int funcionId);
        object Delete(int id);
        public object AddFunctionAndReturn(FuncionesDTO entity);
        public bool VerificarHorarioSala(TimeSpan horario, int idsala, DateTime fecha);
        List<FuncionViwDTO> GetFuncionesDePelicula(int id);
        object GetFuncionesCondicional(string fecha, string titulo);
        public bool ValidarPkPelicula(int peliculaId);
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


        public object AddFunctionAndReturn(FuncionesDTO entity)
        {
            try
            {

                if (ValidarPkPelicula(entity.PeliculaId))
                {
                    DateTime fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null);
                    if (!VerificarHorarioSala(Convert.ToDateTime(entity.Horario).TimeOfDay, entity.SalaId, fecha))
                    {
                        var NewFuncion = new Funciones()
                        {
                            PeliculaId = entity.PeliculaId,
                            Fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null),
                            Horario = Convert.ToDateTime(entity.Horario).TimeOfDay,
                            SalaId = entity.SalaId
                        };

                        genericsRepository.Add<Funciones>(NewFuncion);
                        return entity;

                    }
                    return "Ese espacio horario ya esta asignado"; 
                }
                return "No existe esa pelicula";
            }
            catch (Exception e)
            {

                return e.Message;
            }

        }

       

        public object Delete(int id)
        {
            var Funcion = (from x in context.Funciones where x.FuncionId == id select x).FirstOrDefault<Funciones>();
            if (Funcion != null)
            {
                genericsRepository.Delete<Funciones>(Funcion);
                return "La funcion fue borrada";
            }
            else 
            {
                return "No existe esa funcion";
            }
            

        }

      

       

        public List<FuncionViwDTO> GetFuncionesDePelicula(int id)
        {
            
            List<FuncionViwDTO> funcionViwDTOs = new List<FuncionViwDTO>();
            var funciones= _query.GuetFuncionesByIdFilm(id);
            foreach (Funciones fun in funciones)
            {
                FuncionViwDTO Funcion = new FuncionViwDTO
                {
                    funcionId = fun.FuncionId,
                    PeliculaNombre = (from x in context.Peliculas where x.PeliculaId == fun.PeliculaId select x.Titulo).FirstOrDefault<string>(),
                    SalaId = fun.SalaId,
                    Fecha = fun.Fecha.ToShortDateString(),
                    Horario = fun.Horario.ToString()
                };
                funcionViwDTOs.Add(Funcion);
            }
            return funcionViwDTOs;
        }

       

        public bool VerificarHorarioSala(TimeSpan horario, int idsala,DateTime fecha)
        {
            TimeSpan horasDeFuncionStandar =DateTime.Parse("2:30:00").TimeOfDay;
                
                List<Funciones> funcion = (from x in context.Funciones where x.SalaId == idsala & x.Fecha==fecha select x).ToList();
            if (funcion.Any())
                {
                    foreach (Funciones funciones in funcion)
                    {

                        if (funciones.Horario + horasDeFuncionStandar > horario)
                            return true;
                    }
                }       
            return false;
        }
        public int GetTicketsRestantes(int funcionId)
        {
            int IdSala = (from x in context.Funciones where x.FuncionId == funcionId select x.SalaId).FirstOrDefault<int>();
            int capacidadDeSala = (from x in context.Salas where x.SalasId == IdSala select x.Capacidad).FirstOrDefault<int>();
            int TiketParaFuncion = (from x in context.Tickets where x.FuncionId == funcionId select x).Count();
            return capacidadDeSala - TiketParaFuncion;
        }

        public object GetFuncionesCondicional(string fecha, string titulo)
        {
            if (string.IsNullOrEmpty(fecha))
                fecha = DateTime.Now.ToString("dd/MM/yyyy");

            return _query.GetPeliculasCondicional(fecha, titulo);
        }

        public bool ValidarPkPelicula(int peliculaId)
        {
            Peliculas pelicula = (from x in context.Peliculas where x.PeliculaId == peliculaId select x).FirstOrDefault<Peliculas>();
            if (pelicula != null)
                return true;
            else
                return false;
        }
    }
}
