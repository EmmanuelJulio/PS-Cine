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
                    new ConfigPeliculas(modelBuilder.Entity<PeliculaDTO>());
                    modelBuilder.Entity<PeliculaDTO>(entity =>
                {
                    entity.ToTable("Peliculas");
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 1,
                        Titulo = "Furia de titanes",
                        Poster = "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcR48OaOQHVg55Y9U7v1VD7Cby9_kgc5pcAGUzCvSptDiccLtzjQ",
                        Sinospsis = "Perseo, hijo de Zeus y una mortal, se embarca en una peligrosa misión para salvar la vida de la princesa Andrómeda.",
                        Trailer = "https://www.youtube.com/watch?v=cfk-eagYt9Q"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 2,
                        Titulo = "Iron Man 1",
                        Poster = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT95Db6V4jzEkaZjnWEV5n0qHu1a2InkUgafj3lWQDRxQIxYvL3",
                        Sinospsis = "Iron Man es la historia del industrial multimillonario y genio inventor Tony Stark (ROBERT DOWNEY JR.). ... ",
                        Trailer = "https://www.youtube.com/watch?v=8ugaeA-nMTc"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 3,
                        Titulo = "Hulk",
                        Poster = "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/el-increible-hulk-1554403044.jpg?crop=1xw:0.8888888888888888xh;center,top&resize=1200:*",
                        Sinospsis = "Bruce Banner recorre el mundo en busca de un antídoto para librarse de su alter ego. Además tendrá que hacer frente a Emil, un nuevo enemigo",
                        Trailer = "https://www.youtube.com/watch?v=xbqNb2PFKKA"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 4,
                        Titulo = "Frozen 2",
                        Poster = "https://m.media-amazon.com/images/I/714arK1ZtCL._AC_SY741_.jpg",
                        Sinospsis = "Una profecía condena al reino de Arandelle a vivir en un invierno eterno. La joven Anna, el temerario montañero Kristoff y el reno Sven deben emprender un viaje épico",
                        Trailer = "https://www.youtube.com/watch?v=QTvcYow0Z5U"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 5,
                        Titulo = "Jurassic World",
                        Poster = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQzsbrQ-CBlRMcqxEIuxg_ZJYj_da8ze8mqFRPUGG6o-jBh103S",
                        Sinospsis = "Han pasado 22 años desde que el millonario John Hammond clonara el primer dinosaurio. Con tecnologías mejoradas y nuevas medidas de seguridad",
                        Trailer = "https://www.youtube.com/watch?v=QTvcYow0Z5U"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 6,
                        Titulo = "El rey leon",
                        Poster = "https://es.web.img3.acsta.net/pictures/19/07/09/11/22/4517830.jpg",
                        Sinospsis = "Tras la muerte de su padre, Simba deberá enfrentarse a su tío para recuperar el trono de Rey de la Selva. Timón y Pumba le acompañarán en su misión.",
                        Trailer = "https://www.youtube.com/watch?v=mb79ctR-E-c"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 7,
                        Titulo = "Vengadores: Infinity War",
                        Poster = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSOV0JVW82VnxHBgHu1syHyD_cTSYAgLr76gw9ejI4cmySydjmw",
                        Sinospsis = "Los superhéroes se alían para vencer al poderoso Thanos, el peor enemigo al que se han enfrentado. Si Thanos logra reunir las seis gemas del infinito",
                        Trailer = "https://youtu.be/-f5PwE_Q8Fs"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 8,
                        Titulo = "Titanic",
                        Poster = "https://www.ecartelera.com/carteles/2400/2425/002_m.jpg",
                        Sinospsis = "Jack es un joven artista que gana un pasaje para viajar a América en el Titanic, el transatlántico más grande y seguro jamás construido. ",
                        Trailer = "https://www.youtube.com/watch?v=FiRVcExwBVA"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 9,
                        Titulo = "Vengadores End Game",
                        Poster = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.abc.es%2Fplay%2Fpelicula%2Fvengadores-endgame-52759%2F&psig=AOvVaw1Vp2ZWkD-Ska57oIuICNOu&ust=1631149888507000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCKDPyP-Y7vICFQAAAAAdAAAAABAD",
                        Sinospsis = "Después de los eventos devastadores de infiniti wards, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. ",
                        Trailer = "https://www.youtube.com/watch?v=UQ3bqYKnyhM"
                    });
                    entity.HasData(new PeliculaDTO
                    {
                        PeliculaId = 10,
                        Titulo = "Avatar",
                        Poster = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.filmaffinity.com%2Fes%2Ffilm495280.html&psig=AOvVaw1GChqFQ6_sWprcqFmAwDSH&ust=1631150036425000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCKD1jcaZ7vICFQAAAAAdAAAAABAD",
                        Sinospsis = "En un exuberante planeta llamado Pandora viven los Na'vi, seres que aparentan ser primitivos pero que en realidad son muy evolucionados.",
                        Trailer = "https://www.youtube.com/watch?v=g5deg0HgCmY"
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
            public DbSet<PeliculaDTO> Peliculas { get; set; }
            public DbSet<Tickets> Tickets { get; set; }
            public DbSet<Salas> Salas { get; set; }

        
    }
}
