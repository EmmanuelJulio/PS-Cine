using PS.DOMAIN.Queries;
using SqlKata.Compilers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlKata.Execution;
using PS.DOMAIN.DTOs;
using PS.DOMAIN.Entities;

namespace PS.DATE.Queries
{
    public class FuncionQuery : IFuncionQuery
    {
       
        private readonly ApplicationDbContext context;

        public FuncionQuery( ApplicationDbContext context)
        {
    
            this.context = context;
        }

        public Funciones GetFuncion(int id)
        {
            return (from x in context.Funciones where x.FuncionId == id select x).FirstOrDefault<Funciones>();
        }

        public object GetFuncionesDePelicula(int id)
        {

            return (from x in context.Funciones
                    join peliculas in context.Peliculas on x.PeliculaId equals peliculas.PeliculaId
                    where x.PeliculaId == id
                    select new FuncionViwDTO { funcionId = x.FuncionId, PeliculaNombre = peliculas.Titulo, SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(), Horario = x.Horario.ToString(@"hh\:mm\:ss") }).ToList<FuncionViwDTO>();
            
        }

        public FuncionByIdDTO GetFuncionVideo(int id)
        {
               return (from x in context.Funciones
                    join peliculas in context.Peliculas on x.PeliculaId equals peliculas.PeliculaId
                    where x.FuncionId == id
                    select new FuncionByIdDTO { 
                        funcionId = x.FuncionId,
                        poster=peliculas.Poster,
                        sinopsis=peliculas.Sinopsis,
                        PeliculaNombre = peliculas.Titulo,
                        SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(),
                        video=peliculas.Trailer,
                        Horario = x.Horario.ToString(@"hh\:mm") }).FirstOrDefault<FuncionByIdDTO>();
        }

        public ResponseDTO<Funciones> GuetFuncionesByIdFilm(int id)
        {
            ResponseDTO<Funciones> response = new ResponseDTO<Funciones>();
            response.Data = (from x in context.Funciones where x.PeliculaId == id && x.Fecha >= DateTime.Now.Date select x).ToList();
            return response;
           
        }

        public object ReturnPorFecha(string fecha)
        {
       
            List<FuncionViwDTO> funciones = new List<FuncionViwDTO>();
            
                funciones = (from x in context.Funciones
                                 join Peliculas in context.Peliculas on x.PeliculaId equals Peliculas.PeliculaId
                                 where x.Fecha == Convert.ToDateTime(fecha)
                                 select new FuncionViwDTO { funcionId = x.FuncionId,poster=Peliculas.Poster,sinopsis=Peliculas.Sinopsis, PeliculaNombre = Peliculas.Titulo, SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(), Horario = x.Horario.ToString(@"hh\:mm") }
                                   ).ToList<FuncionViwDTO>();

            return funciones;
        }

       

        public object ReturnPorNombre(string titulo)
        {
            List<FuncionViwDTO> funciones = new List<FuncionViwDTO>();
           
                funciones = (from x in context.Funciones
                                 join Peliculas in context.Peliculas on x.PeliculaId equals Peliculas.PeliculaId
                                 where Peliculas.Titulo == titulo && x.Fecha == DateTime.Now.Date
                                 select new FuncionViwDTO { funcionId = x.FuncionId,sinopsis= Peliculas.Sinopsis,poster= Peliculas.Poster, PeliculaNombre = Peliculas.Titulo, SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(), Horario = x.Horario.ToString(@"hh\:mm") }
                                ).ToList<FuncionViwDTO>();
                return funciones;
           
            
             
        }

        public object ReturnPorNombreYFecha(string fecha, string titulo)
        {
            List<FuncionViwDTO> funciones = new List<FuncionViwDTO>();
            funciones = (from x in context.Funciones
                                 join Peliculas in context.Peliculas on x.PeliculaId equals Peliculas.PeliculaId
                                 where x.Fecha == Convert.ToDateTime(fecha) && x.Fecha == Convert.ToDateTime(fecha) && Peliculas.Titulo==titulo
                                 select new FuncionViwDTO { funcionId = x.FuncionId, PeliculaNombre = Peliculas.Titulo,poster=Peliculas.Poster,sinopsis=Peliculas.Sinopsis, SalaId = x.SalaId, Fecha = x.Fecha.ToShortDateString(), Horario = x.Horario.ToString(@"hh\:mm") }
                              ).ToList<FuncionViwDTO>();
                return funciones;
           
           
        }

        public TicketsRestantesDTO TicketsRestantes(int funcionId)
        {
            
          
                
                int IdSala = (from x in context.Funciones where x.FuncionId == funcionId select x.SalaId).FirstOrDefault<int>();
                int capacidadDeSala = (from x in context.Salas where x.SalasId == IdSala select x.Capacidad).FirstOrDefault<int>();
                int TiketParaFuncion = (from x in context.Tickets where x.FuncionId == funcionId select x).Count();
            TicketsRestantesDTO tiket = new TicketsRestantesDTO()
            {
                ticketsRestantes = capacidadDeSala - TiketParaFuncion
            };
           
                return tiket;
                
           

        }
    }
}
