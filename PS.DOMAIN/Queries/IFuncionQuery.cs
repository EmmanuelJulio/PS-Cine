using PS.DOMAIN.DTOs;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DOMAIN.Queries
{
    public interface IFuncionQuery
    {
        ResponseDTO<Funciones> GuetFuncionesByIdFilm(int id);
        object ReturnPorNombre(string titulo);
        object ReturnPorNombreYFecha(string fecha, string titulo);
      
        object ReturnPorFecha(string fecha);
        TicketsRestantesDTO TicketsRestantes(int funcionId);
        object GetFuncionesDePelicula(int id);
        Funciones GetFuncion(int id);
        FuncionByIdDTO GetFuncionVideo(int id);
    }
}
