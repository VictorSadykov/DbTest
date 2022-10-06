using DbTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbTest.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(MyDbContext db)
        {
            Table = db.Books;
        }

        /// <summary>
        /// Получить список книг определенного жанра и вышедших между определенными годами.
        /// </summary>
        /// <param name="genreName"></param>
        /// <param name="year1"></param>
        /// <param name="year2"></param>
        /// <returns></returns>
        public List<Book> GetBooksWithGenreAndYears(string genreName, int year1, int year2)
        {
            var query = Table.Where(book =>
                                    book.Genre.Name == genreName &&
                                    book.ReleaseYear > year1 &&
                                    book.ReleaseYear < year2);

            return query.ToList();
        }

        /// <summary>
        /// Получить количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="authorName"></param>
        /// <returns></returns>
        public int CountBooksByAuthorName(string authorName)
        {
            var query = Table.Where(book => book.Author.Name == authorName);
            return query.Count();
        }

        /// <summary>
        /// Получить количество книг определенного автора в библиотеке.
        /// </summary>
        /// <param name="genreName"></param>
        /// <returns></returns>
        public int CountBooksByGenre(string genreName)
        {
            var query = Table.Where(book => book.Genre.Name == genreName);
            return query.Count();
        }

        /// <summary>
        /// Получить булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке.
        /// </summary>
        /// <param name="authorName"></param>
        /// <param name="bookName"></param>
        /// <returns></returns>
        public bool IsThereBookWithCertainAuthorAndBookName(int authorId, string bookName)
        {
            return Table.Any(book => book.Name == bookName && book.Author.Id == authorId);
        }

        /// <summary>
        /// Получение последней вышедшей книги.
        /// </summary>
        /// <returns></returns>
        public Book GetLatestBook()
        {
            var booksOrdered = Table.OrderByDescending(book => book.ReleaseYear);
            return booksOrdered.FirstOrDefault();
        }

        /// <summary>
        /// Получение списка всех книг, отсортированного в алфавитном порядке по названию.
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksInAlphabeticalOrder()
        {
            return Table.OrderBy(book => book.Name).ToList();
        }

        public List<Book> GetAllBooksInYearOrderDescended()
        {
            return Table.OrderByDescending(book => book.ReleaseYear).ToList();
        }
    }
}
