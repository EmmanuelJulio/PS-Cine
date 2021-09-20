using PS.APLICATION.Services;
using PS.APLICATION.Validations;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.CINE
{
    public interface IOptions
    {
        public void Option1();
        public void Option2();
        public void Option3();
        public void Option4();
        public void Option5();
        public void Option6();

    }
    public class Options : IOptions
    {

        private readonly FuncionService funcionService;
        private readonly PeliculaService peliculaService;
        private readonly SalaService salaService;
        private readonly TicketService ticketService;
        private readonly FuncionValidation funcionValidation;
        private readonly SalaValidation salaValidation;

        public Options(FuncionService funcionService, PeliculaService peliculaService, SalaService salaService, TicketService ticketService, FuncionValidation funcionValidation, SalaValidation salaValidation)
        {
            this.funcionService = funcionService;
            this.peliculaService = peliculaService;
            this.salaService = salaService;
            this.ticketService = ticketService;
            this.funcionValidation = funcionValidation;
            this.salaValidation = salaValidation;
        }

        public void Option1()
        {
            foreach (var film in peliculaService.MostrarPeliculas())
            {
                Console.WriteLine("Id de pelicula " + film.PeliculaId);
                Console.WriteLine("Titulo: " + film.Titulo);
            }
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadLine();
        }

        public void Option2()
        {
            foreach (var film in peliculaService.MostrarPeliculas())
            {
                Console.WriteLine("Id = " + film.PeliculaId+ " Titulo: " + film.Titulo);
             
            }
            Console.WriteLine("Ingrese el identificador de la pelicula para ver si hay funciones disponibles");
            try
            {
                List<Funciones> funciones = funcionService.FuncionesDisponibles(Convert.ToInt32(Console.ReadLine()));
                if (funciones.Count != 0)
                {
                    Console.WriteLine("-------------------------------------");
                    foreach (var funcion in funciones)
                    {

                        Console.WriteLine("Id de Funcion 1" + funcion.FuncionId);
                        Console.WriteLine("Nombre de la funcion " + peliculaService.NombrePeliculaPorId(funcion.PeliculaId));
                        Console.WriteLine(funcion.Horario);
                        Console.WriteLine("-------------------------------------");

                    }
                }
                else
                {
                    Console.WriteLine("No hay funciones disponibles para este film");
                }
                Console.WriteLine("Precione una tecla para continuar...");
            }
            catch (Exception)
            {

                Console.WriteLine("Seleccione una opcion valida");
            }
            Console.ReadLine();
        }

        public void Option3()
        {
            Console.WriteLine("------------------------------------------------------------------");
            foreach (var peli in peliculaService.MostrarPeliculas())
            {
                Console.WriteLine("Id = " + peli.PeliculaId + " Nombre = " + peli.Titulo);
            }
            Console.WriteLine("------------------------------------------------------------------");
            Console.WriteLine("Ingrese el identificador del film para ver mas informacion de este");
            try
            {
                int idFilm2 = Convert.ToInt32(Console.ReadLine());
                List<Peliculas> pelicula = peliculaService.MasInformacionDeFilm(idFilm2);
               
                foreach (var film in pelicula)
                {

                    Console.WriteLine("Identificador " + film.PeliculaId);
                    Console.WriteLine("Titulo: " + film.Titulo);
                    Console.WriteLine("Poster: " + film.Poster);
                    Console.WriteLine("Sinopsis:  " + film.Sinospsis);
                    Console.WriteLine("Trailer: " + film.Trailer);

                }
               

            }
            catch (Exception)
            {

                Console.WriteLine("Debe ingresar un identificador valido");
            }
            Console.WriteLine("Precione una tecla para continuar...");
            Console.ReadLine();
        }

        public void Option4()
        {
            List<Peliculas> peliculas3 = peliculaService.MostrarPeliculas();
            foreach (var film in peliculas3)
            {
                Console.WriteLine("Id = " + film.PeliculaId +" Titulo: " + film.Titulo);
            }
            Console.WriteLine("Seleccione una pelicula para crear una funcion");
            try
            {
                int idpelicula = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Seleccione un horario hh:mm");
                TimeSpan horaFuncion = TimeSpan.Parse(Console.ReadLine());
                Console.WriteLine("Seleccione una sala");
                foreach (var Sala in salaService.MostrarSalas())
                {
                    Console.WriteLine("Id sala " + Sala.SalasId);
                    Console.WriteLine("capacidad sala " + Sala.Capacidad);
                }
                
                funcionValidation.CrearFuncion(idpelicula, horaFuncion, Convert.ToInt32(Console.ReadLine()));
            }
            catch (Exception)
            {

                Console.WriteLine("Seleccione una opcion valida");
            }
            Console.ReadLine();
        }

        public void Option5()
        {
            String NombrePelicula;
            Console.WriteLine("Seleccione una sala");
            

            foreach (var sala in salaService.MostrarSalas())
            {
                Console.WriteLine("id sala " + sala.SalasId);
            }
            int idsala = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Seleccione una funcion ");
            foreach (var funcion in funcionService.FuncionesDisponiblesEnSala(idsala))
            {
                NombrePelicula = peliculaService.NombrePeliculaPorId(funcion.PeliculaId);
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("id funcion = " + funcion.FuncionId);
                Console.WriteLine("Titulo de la funcion " + NombrePelicula);
                Console.WriteLine("Horario de funcion = " + funcion.Horario.ToString());
                Console.WriteLine("Capacidad de la sala " + salaService.capacidadDeSala(idsala));
                Console.WriteLine("Capacidad restante de sala = " + salaValidation.PuestosRestantesEnSala(idsala, funcion.FuncionId).ToString());
                Console.WriteLine("---------------------------------------------------------------------------");

            }
            Console.WriteLine("Seleccione la funcion a la cual quiere asistir");
            int opcionfuncion = Convert.ToInt32(Console.ReadLine());
            int capsala = salaService.capacidadDeSala(idsala);
            int ocupacionDeSala = funcionValidation.VerificarCapacidadDelaFuncion(idsala, opcionfuncion);
            if (capsala > ocupacionDeSala)
            {

                Tickets NewTicket = new Tickets();
                NewTicket.FuncionId = opcionfuncion;
                Funciones funcionEscogida = funcionService.OptenerFuncionPorId(opcionfuncion);
                Console.WriteLine("Escribe tu nombre, el mismo sera pedido para la entrega de los tickets");
                NewTicket.Usuario = Console.ReadLine();
                ticketService.AgregarTikets(NewTicket);
                Console.Clear();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("Su tiket fue comprado con exito Sr/ra");
                Console.WriteLine("--------------------------------------------");
                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Esa sala se encuentra completa, seleccione otra por favor");
                Console.ReadLine();
            }


        }

        public void Option6()

        {
            Console.WriteLine("Seleccione una funcion");
            foreach (var funcion in funcionService.OptenerTodasLasFunciones())
            {
                string NombrePelicula = peliculaService.NombrePeliculaPorId(funcion.PeliculaId);
                Console.WriteLine("---------------------------------------------------------------------------");
                Console.WriteLine("id funcion = " + funcion.FuncionId);
                Console.WriteLine("Titulo de la funcion " + NombrePelicula);
                Console.WriteLine("---------------------------------------------------------------------------");           
            }
            int FuncionEscogida=Convert.ToInt32(Console.ReadLine());
            Funciones funcionEscogida =  funcionService.OptenerFuncionPorId(FuncionEscogida);
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("id funcion = " + funcionEscogida.FuncionId);
            Console.WriteLine("Titulo de la funcion " + peliculaService.NombrePeliculaPorId(funcionEscogida.PeliculaId));
            Console.WriteLine("Horario de funcion = " + funcionEscogida.Horario.ToString());
            Console.WriteLine("Capacidad de la sala " + salaService.capacidadDeSala(funcionEscogida.SalaId));
            Console.WriteLine("Capacidad restante de sala = " + salaValidation.PuestosRestantesEnSala(funcionEscogida.SalaId, funcionEscogida.FuncionId).ToString());
            Console.WriteLine("---------------------------------------------------------------------------");
            Console.WriteLine("Precione una tecla para salir");
            Console.ReadLine();
        }

    }
}
