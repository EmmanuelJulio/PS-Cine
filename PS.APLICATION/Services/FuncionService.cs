using Microsoft.EntityFrameworkCore;
using PS.APLICATION.Validations;
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
        public ResponseDTO<object> GetTicketsRestantes(int funcionId);
        public ResponseDTO<object> Delete(int id);
        public ResponseDTO<FuncionesDTO> AddFunctionAndReturn(FuncionesDTO entity);
        
         public ResponseDTO<object> GetFuncionesDePelicula(int id);
         public ResponseDTO<object> GetFuncionesCondicional(string fecha, string titulo);
        ResponseDTO<object> GetFuncionById(int id);
    }


    public class FuncionService: IFuncionService
    {
        private readonly IFuncionValidation funcionValidation;
        private readonly IGenericsRepository genericsRepository;
        private readonly ApplicationDbContext context;
        private readonly IFuncionQuery _query;
        private readonly IFuncionValidation validation;
        private readonly IPeliculaValidation PeliculaValidation;
        private readonly ISalaValidation salaValidation;

        public FuncionService(IFuncionValidation funcionValidation, IGenericsRepository genericsRepository, ApplicationDbContext context, IFuncionQuery query, IFuncionValidation validation, IPeliculaValidation peliculaValidation, ISalaValidation salaValidation)
        {
            this.funcionValidation = funcionValidation;
            this.genericsRepository = genericsRepository;
            this.context = context;
            _query = query;
            this.validation = validation;
            PeliculaValidation = peliculaValidation;
            this.salaValidation = salaValidation;
        }

        public ResponseDTO<FuncionesDTO> AddFunctionAndReturn(FuncionesDTO entity)
        {
            ResponseDTO<FuncionesDTO> responseDTO = new ResponseDTO<FuncionesDTO>();
            try
            {
                if (salaValidation.VerificarExisteSala(entity.SalaId))
                {
                    if (PeliculaValidation.ValidarPkPelicula(entity.PeliculaId))
                    {
                        DateTime fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null);
                        if (!salaValidation.VerificarHorarioSala(Convert.ToDateTime(entity.Horario).TimeOfDay, entity.SalaId, fecha))
                        {
                            var NewFuncion = new Funciones()
                            {
                                PeliculaId = entity.PeliculaId,
                                Fecha = DateTime.ParseExact(entity.Fecha, "dd/MM/yyyy", null),
                                Horario = Convert.ToDateTime(entity.Horario).TimeOfDay,
                                SalaId = entity.SalaId
                            };

                            genericsRepository.Add<Funciones>(NewFuncion);


                            responseDTO.Data.Add(entity);
                            return responseDTO;
                        }
                        else
                        {
                            responseDTO.Response.Add("Ese espacio horario ya esta asignado");
                            return responseDTO;
                        }

                    }
                    else
                    {
                        responseDTO.Response.Add("Id de pelicula ineccistente inexistente");
                        return responseDTO;
                    }

                }
                else
                {
                    responseDTO.Response.Add("No existe esa sala");
                    return responseDTO;
                }
            }
            catch (Exception e)
            {

                responseDTO.Response.Add(e.Message);
                return responseDTO;
            }

        }






        public ResponseDTO<object> Delete(int id)
        {
            ResponseDTO<object> responseDTO = new ResponseDTO<object>();
            Funciones Funcion = _query.GetFuncion(id);
           
            if (Funcion != null)
            {
                genericsRepository.Delete<Funciones>(Funcion);
                FuncionDeleteDTO func = new FuncionDeleteDTO
                {
                    FuncionId = Funcion.FuncionId
                };
                responseDTO.Data.Add(func);
                return responseDTO;
            }
            else 
            {
                responseDTO.Response.Add("Id inexistente");
                return responseDTO;
            }
            

        }

      

       

        public ResponseDTO<object> GetFuncionesDePelicula(int id)
        {
            ResponseDTO<object> response = new ResponseDTO<object>();

            if (PeliculaValidation.ValidarPkPelicula(id))
            {
                response.Data.Add(_query.GetFuncionesDePelicula(id));
                return response;
            }
            else
            {
                response.Response.Add("Id inexistente");
                return response;
            }
        }

       

       
        public ResponseDTO<object> GetTicketsRestantes(int funcionId)
        {
            ResponseDTO<object> response = new ResponseDTO<object>();
            if (funcionValidation.ValidarFuncion(funcionId))
            {
                response.Data.Add(_query.TicketsRestantes(funcionId));
                return response;
            }
            else
            {
                response.Response.Add("Id inexistente");
                return response;
            }
           
            
          
        }

        public ResponseDTO<object> GetFuncionesCondicional(string fecha, string titulo)
        {
            
            ResponseDTO<object> response = new ResponseDTO<object>();

            try
            {
                if (!validation.ValidateParametersRequest(fecha, titulo))
                {
                    response.Response.Add("Debe completar almenos un campo");
                    return response;
                }

                if (string.IsNullOrEmpty(fecha))
                {
                    response.Data.Add(_query.ReturnPorNombre(titulo));
                    return response;

                }
                else if (!string.IsNullOrEmpty(fecha) && !string.IsNullOrEmpty(titulo))
                {
                    response.Data.Add(_query.ReturnPorNombreYFecha(fecha, titulo));
                    return response;
                }

                response.Data.Add(_query.ReturnPorFecha(fecha));
                return response;
            }
            catch (Exception e)
            {

                response.Response.Add(e.Message);
                return response;
            }
       
        }

        public ResponseDTO<object> GetFuncionById(int id)
        {
            ResponseDTO<object> response = new ResponseDTO<object>();
            response.Data.Add(_query.GetFuncionVideo(id));
            return response;
        }
    }
}
