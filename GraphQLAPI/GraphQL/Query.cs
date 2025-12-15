using GraphQLAPI.Data;
using GraphQLAPI.Models;

namespace GraphQLAPI.GraphQL
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public IQueryable<Book> GetBooks(AppDbContext context) =>
            context.Books;
    }
}
