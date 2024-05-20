using Microsoft.EntityFrameworkCore;

using System.Web.UI;

namespace Gerenciadordetarefas.modelo


public class appdatacontext : DbContext
{
    
    public DbSet<Tarefa> Tarefas { get; set; }

     public DbSet<NaoIniciada> NaoIniciadas { get; set; }

      public DbSet<EmAndamento> EmAndamentos { get; set; }

       public DbSet<Terminada>  Terminadas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
        optionsBuilder.UseSqlite("Data Source=banco.db");
    }
}