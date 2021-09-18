using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PS.APLICATION.Services;
using PS.APLICATION.Validations;
using PS.DATE;
using PS.DATE.Command;
using PS.DOMAIN.Comands;

namespace PS.CINE
{
    public class Program
    {
        

        static void Main(string[] args)
        {
            

            var context = new ApplicationDbContext();
            var repository = new GenericRepository(context);
            var funcionservice = new FuncionService(repository,context);
            var peliculaservice = new PeliculaService(repository, context);
            var salaservice = new SalaService(repository, context);
            var ticketservice = new TicketService(repository, context);
            var functionvaldiation = new FuncionValidation(funcionservice,context);
            var salavalidation = new SalaValidation(context);



            Options options = new Options(funcionservice, peliculaservice, salaservice, ticketservice, functionvaldiation, salavalidation);
            Menu menu = new Menu(options);
            menu.cartelera();





        }



    }
}
