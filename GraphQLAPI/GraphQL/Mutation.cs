using GraphQLAPI.Data;
using GraphQLAPI.Models;

namespace GraphQLAPI.GraphQL
{
    public class Mutation
    {
        public Book CreateBook(AppDbContext context, string title, string author)
        {
            var book = new Book
            {
                Title = title,
                Author = author
            };
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book UpdateBook(AppDbContext context, int id, string title, string author)
        {
            var book = context.Books.Find(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            book.Title = title;
            book.Author = author;
            context.SaveChanges();
            return book;
        }

        public bool DeleteBook(AppDbContext context, int id)
        {
            var book = context.Books.Find(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            context.Books.Remove(book);
            context.SaveChanges();
            return true;
        }
    }
}
