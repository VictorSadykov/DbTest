using DbTest.Repositories;
using DbTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyDbContext db = new MyDbContext();
            UserRepository userRepository = new UserRepository(db);
            BookRepository bookRepository = new BookRepository(db);
            using (db)
            {
                

            }
        }
    }
}
