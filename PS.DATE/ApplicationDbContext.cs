using Microsoft.EntityFrameworkCore;
using PS.DATE.Config;
using PS.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        :base (options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            {
              

            }

            protected override void OnModelCreating(ModelBuilder modelBuilder)

            {

                    new ConfigFunciones(modelBuilder.Entity<Funciones>());
                    new ConfigTickets(modelBuilder.Entity<Tickets>());
                    new ConfigSalas(modelBuilder.Entity<Salas>());
                    new ConfigPeliculas(modelBuilder.Entity<Peliculas>());
                    modelBuilder.Entity<Peliculas>(entity =>
                {
                    entity.ToTable("Peliculas");
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 1,
                        Titulo = "Furia de titanes",
                        Poster = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcR48OaOQHVg55Y9U7v1VD7Cby9_kgc5pcAGUzCvSptDiccLtzjQ",
                        Sinopsis = "Perseo, hijo de Zeus y una mortal, se embarca en una peligrosa misión para salvar la vida de la princesa Andrómeda.",
                        Trailer = "https://www.youtube.com/embed/cfk-eagYt9Q"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 2,
                        Titulo = "Iron Man 1",
                        Poster = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT95Db6V4jzEkaZjnWEV5n0qHu1a2InkUgafj3lWQDRxQIxYvL3",
                        Sinopsis = "Iron Man es la historia del industrial multimillonario y genio inventor Tony Stark (ROBERT DOWNEY JR.). ... ",
                        Trailer = "https://www.youtube.com/embed/8ugaeA-nMTc"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 3,
                        Titulo = "Hulk",
                        Poster = "https://i.blogs.es/c75dea/incredible_hulk/450_1000.jpg",
                        Sinopsis = "Bruce Banner recorre el mundo en busca de un antídoto para librarse de su alter ego. Además tendrá que hacer frente a Emil, un nuevo enemigo",
                        Trailer = "https://www.youtube.com/embed/xbqNb2PFKKA"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 4,
                        Titulo = "Frozen 2",
                        Poster = "https://m.media-amazon.com/images/I/714arK1ZtCL._AC_SY741_.jpg",
                        Sinopsis = "Una profecía condena al reino de Arandelle a vivir en un invierno eterno. La joven Anna, el temerario montañero Kristoff y el reno Sven deben emprender un viaje épico",
                        Trailer = "https://www.youtube.com/embed/QTvcYow0Z5U"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 5,
                        Titulo = "Jurassic World",
                        Poster = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQzsbrQ-CBlRMcqxEIuxg_ZJYj_da8ze8mqFRPUGG6o-jBh103S",
                        Sinopsis = "Han pasado 22 años desde que el millonario John Hammond clonara el primer dinosaurio. Con tecnologías mejoradas y nuevas medidas de seguridad",
                        Trailer = "https://www.youtube.com/embed/RFinNxS5KN4"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 6,
                        Titulo = "El rey leon",
                        Poster = "https://es.web.img3.acsta.net/pictures/19/07/09/11/22/4517830.jpg",
                        Sinopsis = "Tras la muerte de su padre, Simba deberá enfrentarse a su tío para recuperar el trono de Rey de la Selva. Timón y Pumba le acompañarán en su misión.",
                        Trailer = "https://www.youtube.com/embed/mb79ctR-E-c"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 7,
                        Titulo = "Vengadores: Infinity War",
                        Poster = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSOV0JVW82VnxHBgHu1syHyD_cTSYAgLr76gw9ejI4cmySydjmw",
                        Sinopsis = "Los superhéroes se alían para vencer al poderoso Thanos, el peor enemigo al que se han enfrentado. Si Thanos logra reunir las seis gemas del infinito",
                        Trailer = "https://www.youtube.com/embed/-f5PwE_Q8Fs"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 8,
                        Titulo = "Titanic",
                        Poster = "https://www.ecartelera.com/carteles/2400/2425/002_m.jpg",
                        Sinopsis = "Jack es un joven artista que gana un pasaje para viajar a América en el Titanic, el transatlántico más grande y seguro jamás construido. ",
                        Trailer = "https://www.youtube.com/embed/FiRVcExwBVA"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 9,
                        Titulo = "Vengadores End Game",
                        Poster = "https://pics.filmaffinity.com/Vengadores_Endgame-135478227-large.jpg",
                        Sinopsis = "Después de los eventos devastadores de infiniti wards, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. ",
                        Trailer = "https://www.youtube.com/embed/TcMBFSGVi1c"
                    });
                    entity.HasData(new Peliculas
                    {
                        PeliculaId = 10,
                        Titulo = "Avatar",
                        Poster = "https://m.media-amazon.com/images/I/71Sxa5FqLCL._AC_SY741_.jpg",
                        Sinopsis = "En un exuberante planeta llamado Pandora viven los Na'vi, seres que aparentan ser primitivos pero que en realidad son muy evolucionados.",
                        Trailer = "https://www.youtube.com/embed/g5deg0HgCmY"
                    });
                });


                modelBuilder.Entity<Salas>(entity =>
                {
                    entity.ToTable("Salas");
                    entity.HasData(new Salas { SalasId = 1, Capacidad = 5 });
                    entity.HasData(new Salas { SalasId = 2, Capacidad = 15 });
                    entity.HasData(new Salas { SalasId = 3, Capacidad = 30 });

                });
               
            }
            public DbSet<Funciones> Funciones { get; set; }
            public DbSet<Peliculas> Peliculas { get; set; }
            public DbSet<Tickets> Tickets { get; set; }
            public DbSet<Salas> Salas { get; set; }

        
    }
}
