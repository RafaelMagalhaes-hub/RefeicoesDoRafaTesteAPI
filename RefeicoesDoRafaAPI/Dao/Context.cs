using Microsoft.EntityFrameworkCore;
using RefeicoesDoRafaAPI.Models;

namespace RefeicoesDoRafaAPI.Dao
{
    public class Context : DbContext
    {
        

        public Context(DbContextOptions<Context> options) : base(options) 
        { 
            
        }

        public DbSet<Cliente> cliente {get; set;}

        public DbSet<Refeicao> refeicao { get; set;}    

        public DbSet<Endereco> endereco { get; set;}

        public DbSet<Pedido> pedido { get; set;}
    }
}
