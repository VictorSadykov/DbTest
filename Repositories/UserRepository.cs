using DbTest.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest.Repositories
{
    public class UserRepository : BaseRepository<User>
    {
        public UserRepository(MyDbContext db) 
        {
            Table = db.Users;
        }

        /// <summary>
        /// Получить булевый флаг о том, есть ли определенная книга на руках у пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="bookId"></param>
        /// <returns></returns>
        public bool IsSpecificUserHasSpecificBook(int userId, int bookId)
        {
            return Table.Any(user => user.Id == userId && user.Books.Any(book => book.Id == bookId));
        }

        /// <summary>
        /// Получить количество книг на руках у пользователя.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public int CountBooksInUserOwnage(int userId)
        {
            var temp1 = Table.Where(user => user.Id == userId);
            var temp2 = temp1.FirstOrDefault();
            var temp3 = temp2.Books.Count();
            return temp3;
                        
                        
        }

    }
}
