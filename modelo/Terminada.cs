 namespace Gerenciadordetarefas.modelo
 
 
 public class Terminada
    {
        [Key]
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
}