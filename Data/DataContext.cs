using Microsoft.EntityFrameworkCore;
using Api_Produto.Models;

namespace Api_Produto.Data
{
    public class DataContext:DbContext
    {

       public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Filme> Filmes { get; set; }        
    }
}