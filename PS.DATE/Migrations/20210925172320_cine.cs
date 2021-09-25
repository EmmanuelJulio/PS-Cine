using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PS.DATE.Migrations
{
    public partial class cine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    PeliculaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Poster = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Sinospsis = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Trailer = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.PeliculaId);
                });

            migrationBuilder.CreateTable(
                name: "Salas",
                columns: table => new
                {
                    SalasId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salas", x => x.SalasId);
                });

            migrationBuilder.CreateTable(
                name: "Funciones",
                columns: table => new
                {
                    FuncionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PeliculaId = table.Column<int>(type: "int", nullable: false),
                    SalaId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Horario = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funciones", x => x.FuncionId);
                    table.ForeignKey(
                        name: "FK_Funciones_Peliculas_PeliculaId",
                        column: x => x.PeliculaId,
                        principalTable: "Peliculas",
                        principalColumn: "PeliculaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Funciones_Salas_SalaId",
                        column: x => x.SalaId,
                        principalTable: "Salas",
                        principalColumn: "SalasId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TiketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuncionId = table.Column<int>(type: "int", nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => new { x.TiketId, x.FuncionId });
                    table.ForeignKey(
                        name: "FK_Tickets_Funciones_FuncionId",
                        column: x => x.FuncionId,
                        principalTable: "Funciones",
                        principalColumn: "FuncionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "Poster", "Sinospsis", "Titulo", "Trailer" },
                values: new object[,]
                {
                    { 1, "https://encrypted-tbn2.gstatic.com/images?q=tbn:ANd9GcR48OaOQHVg55Y9U7v1VD7Cby9_kgc5pcAGUzCvSptDiccLtzjQ", "Perseo, hijo de Zeus y una mortal, se embarca en una peligrosa misión para salvar la vida de la princesa Andrómeda.", "Furia de titanes", "https://www.youtube.com/watch?v=cfk-eagYt9Q" },
                    { 2, "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcT95Db6V4jzEkaZjnWEV5n0qHu1a2InkUgafj3lWQDRxQIxYvL3", "Iron Man es la historia del industrial multimillonario y genio inventor Tony Stark (ROBERT DOWNEY JR.). ... ", "Iron Man 1", "https://www.youtube.com/watch?v=8ugaeA-nMTc" },
                    { 3, "https://hips.hearstapps.com/hmg-prod.s3.amazonaws.com/images/el-increible-hulk-1554403044.jpg?crop=1xw:0.8888888888888888xh;center,top&resize=1200:*", "Bruce Banner recorre el mundo en busca de un antídoto para librarse de su alter ego. Además tendrá que hacer frente a Emil, un nuevo enemigo", "Hulk", "https://www.youtube.com/watch?v=xbqNb2PFKKA" },
                    { 4, "https://m.media-amazon.com/images/I/714arK1ZtCL._AC_SY741_.jpg", "Una profecía condena al reino de Arandelle a vivir en un invierno eterno. La joven Anna, el temerario montañero Kristoff y el reno Sven deben emprender un viaje épico", "Frozen 2", "https://www.youtube.com/watch?v=QTvcYow0Z5U" },
                    { 5, "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQzsbrQ-CBlRMcqxEIuxg_ZJYj_da8ze8mqFRPUGG6o-jBh103S", "Han pasado 22 años desde que el millonario John Hammond clonara el primer dinosaurio. Con tecnologías mejoradas y nuevas medidas de seguridad", "Jurassic World", "https://www.youtube.com/watch?v=QTvcYow0Z5U" },
                    { 6, "https://es.web.img3.acsta.net/pictures/19/07/09/11/22/4517830.jpg", "Tras la muerte de su padre, Simba deberá enfrentarse a su tío para recuperar el trono de Rey de la Selva. Timón y Pumba le acompañarán en su misión.", "El rey leon", "https://www.youtube.com/watch?v=mb79ctR-E-c" },
                    { 7, "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcSOV0JVW82VnxHBgHu1syHyD_cTSYAgLr76gw9ejI4cmySydjmw", "Los superhéroes se alían para vencer al poderoso Thanos, el peor enemigo al que se han enfrentado. Si Thanos logra reunir las seis gemas del infinito", "Vengadores: Infinity War", "https://youtu.be/-f5PwE_Q8Fs" },
                    { 8, "https://www.ecartelera.com/carteles/2400/2425/002_m.jpg", "Jack es un joven artista que gana un pasaje para viajar a América en el Titanic, el transatlántico más grande y seguro jamás construido. ", "Titanic", "https://www.youtube.com/watch?v=FiRVcExwBVA" },
                    { 9, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.abc.es%2Fplay%2Fpelicula%2Fvengadores-endgame-52759%2F&psig=AOvVaw1Vp2ZWkD-Ska57oIuICNOu&ust=1631149888507000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCKDPyP-Y7vICFQAAAAAdAAAAABAD", "Después de los eventos devastadores de infiniti wards, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. ", "Vengadores End Game", "https://www.youtube.com/watch?v=UQ3bqYKnyhM" },
                    { 10, "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.filmaffinity.com%2Fes%2Ffilm495280.html&psig=AOvVaw1GChqFQ6_sWprcqFmAwDSH&ust=1631150036425000&source=images&cd=vfe&ved=0CAsQjRxqFwoTCKD1jcaZ7vICFQAAAAAdAAAAABAD", "En un exuberante planeta llamado Pandora viven los Na'vi, seres que aparentan ser primitivos pero que en realidad son muy evolucionados.", "Avatar", "https://www.youtube.com/watch?v=g5deg0HgCmY" }
                });

            migrationBuilder.InsertData(
                table: "Salas",
                columns: new[] { "SalasId", "Capacidad" },
                values: new object[,]
                {
                    { 1, 5 },
                    { 2, 15 },
                    { 3, 30 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_PeliculaId",
                table: "Funciones",
                column: "PeliculaId");

            migrationBuilder.CreateIndex(
                name: "IX_Funciones_SalaId",
                table: "Funciones",
                column: "SalaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FuncionId",
                table: "Tickets",
                column: "FuncionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Funciones");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Salas");
        }
    }
}
