
using GraphQLAPI.Data;
using GraphQLAPI.GraphQL;
using Microsoft.EntityFrameworkCore;

namespace GraphQLAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("BooksDb"));

            // Add GraphQL
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddFiltering()
                .AddSorting();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowVue",
                    policy => policy
                        .WithOrigins("http://localhost:50327")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                );
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.UseCors("AllowVue");

            app.MapGraphQL();

            app.Run();
        }
    }
}
