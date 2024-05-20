namespace Gerenciadordetarefas.modelo
 public class NaoIniciada
    {
        [Key]
        public int TarefaId { get; set; }
        public Tarefa Tarefa { get; set; }
    }
