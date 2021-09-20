using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.CINE
{

 

    public class Menu 
    {
        private readonly Options options;

        public Menu(Options options)
        {
            this.options = options;
        }

  
        public void cartelera()
        {
            int opcion = 0;
            bool continuar = true;
  

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("********************************************************************************************************************");
                Console.WriteLine("********************************************************************************************************************");
                Console.WriteLine("*****                               c i n e   p r o y e c t o  s o f t w a r e                                  ****");
                Console.WriteLine("********************************************************************************************************************");
                Console.WriteLine("********************************************************************************************************************");
                Console.WriteLine("1) Lista de peliculas");
                Console.WriteLine("2) Ver funciones disponibles");
                Console.WriteLine("3) Ver mas informacion de una pelicula");
                Console.WriteLine("4) Generar nueva funcion");
                Console.WriteLine("5) Sacar TIket para una funcion");
                Console.WriteLine("6) Ver capacidad restante de funcion");
                Console.WriteLine("7) Salir del menu ");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        options.Option1();
                        break;
                    case 2:
                        options.Option2();
                        break;
                    case 3:
                        options.Option3();
                        break;
                    case 4:
                        options.Option4();
                        break;

                    case 5:
                        options.Option5();
                        break;

                    case 6:
                        options.Option6();
                        break;
                    case 7:
                        Console.WriteLine("Esta seguro que desea salir??");
                        Console.WriteLine("s/n");
                        string decicion = Console.ReadLine();
                        if (decicion == "s")
                            continuar = false;
                        break;
                    default:
                        Console.WriteLine("Elija una opcion valida, precione una tecla para salir");
                        Console.ReadLine();
                        break;
                }
            }


        }

    }
}
