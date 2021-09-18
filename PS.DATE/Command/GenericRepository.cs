using Microsoft.EntityFrameworkCore;
using PS.DOMAIN.Comands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS.DATE.Command
{
    public class GenericRepository : IGenericsRepository
    {
        private readonly ApplicationDbContext context;
        public GenericRepository (ApplicationDbContext dbcontext)
        {
            context = dbcontext;
        }
        public void Add<T>(T entity) where T : class
        {
            context.Add(entity);
            context.SaveChanges();

        }

        public void Delete<T>(T entity) where T : class
        {
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<T> GetALL<T>() where T : class
        {
            DbSet<T> table = null;
            table = context.Set<T>();
            return table.ToList();
        }

        public void Update<T>(T entity) where T : class
        {
            context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
        }


    }
}
