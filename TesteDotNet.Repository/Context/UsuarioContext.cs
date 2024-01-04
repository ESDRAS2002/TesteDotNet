using Microsoft.EntityFrameworkCore;
using TesteDotNet.Repository.Entities.Usuario;

namespace TesteDotNet.Repository.Context
{
    public class UsuarioContext : DbContext //USAR DOIS PONTOS PRA HERDAR CLASSE INTERNA DO C#
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options)  //CLASSE FILHA,
        {
        }

        public DbSet<Usuario> usuarios { get; set; }   //TRAZ A ENTITIES
    }
}

//LIGAÇÃO DO SQL COM C#