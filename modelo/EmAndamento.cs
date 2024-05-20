namespace Gerenciadordetarefas.modelo
 
 public class EmAndamento
    {
        [Key]
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }