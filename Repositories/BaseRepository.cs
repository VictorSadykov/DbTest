using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest.Repositories
{
    public class BaseRepository<T> where T : class
    {
        public DbSet<T> Table { get; set; }

       

        public void Add(T entity)
        {
            Table.Add(entity);
        }

        public T SelectById(int id)
        {
            return Table.Find(id);
        }

        public List<T> SelectAll()
        {
            return Table.ToList();
        }

        public void DeleteById(int id)
        {
            T entityToDelete = SelectById(id);
            Table.Remove(entityToDelete);
        }

        public void DeleteAll()
        {
            List<T> allEntitiesInTable = SelectAll();
            Table.RemoveRange(allEntitiesInTable);
        }
    }
}
