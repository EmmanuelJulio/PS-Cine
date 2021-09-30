﻿using PS.DOMAIN.Queries;
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
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public FuncionQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<Funciones> GuetFuncionesByIdFilm(int id)
        {
            var db = new SqlKata.Execution.QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("Funciones").Where("PeliculaId", "=", id).Where("Fecha",">=",DateTime.Now).Select();
            return query.Get<Funciones>().ToList();
        }
    }
}
