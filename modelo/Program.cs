using Gerenciadordetarefas.modelo;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gerenciadordetarefas 
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDataContext>();

            var app = builder.Build();

            app.MapPost("/Tarefas/cadastrar", ([FromBody] Tarefa tarefa,
                                                [FromServices] AppDataContext ctx) =>
            {
                List<ValidationResult> erros = new List<ValidationResult>();
                if (!Validator.TryValidateObject(
                    tarefa, new ValidationContext(tarefa), erros, true
                ))
                {
                    return Results.BadRequest(erros);
                }

                Tarefa tarefaEncontrada = ctx.Tarefas.FirstOrDefault(x => x.Nome == tarefa.Nome);
                if (tarefaEncontrada != null)
                {
                    return Results.BadRequest("Já existe uma tarefa com o mesmo nome");
                }

                ctx.Tarefas.Add(tarefa);
                ctx.SaveChanges();
                return Results.Created("", tarefa);
            });

            app.MapDelete("/Tarefas/deletar/{id}", ([FromRoute] string id,
                                                     [FromServices] AppDataContext ctx) =>
            {
                Tarefa tarefa = ctx.Tarefas.FirstOrDefault(x => x.Id == id);
                if (tarefa == null)
                {
                    return Results.NotFound("Tarefa não encontrada!");
                }
                ctx.Tarefas.Remove(tarefa);
                ctx.SaveChanges();
                return Results.Ok("Tarefa deletada!");
            });

            app.MapPut("/Tarefas/alterar/{id}", ([FromRoute] string id,
                                                  [FromBody] Tarefa tarefaAlterada,
                                                  [FromServices] AppDataContext ctx) =>
            {
                Tarefa tarefa = ctx.Tarefas.Find(id);
                if (tarefa == null)
                {
                    return Results.NotFound("Tarefa não encontrada!");
                }
                tarefa.Nome = tarefaAlterada.Nome;
                tarefa.Descricao = tarefaAlterada.Descricao;
                tarefa.Valor = tarefaAlterada.Valor;
                ctx.Tarefas.Update(tarefa);
                ctx.SaveChanges();
                return Results.Ok("Tarefa alterada!");
            });

            app.Run();
        }
    }
}
