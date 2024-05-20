 namespace Gerenciadordetarefas.modelo
 
 public class Tarefa
    {
        [Key]
        public int TarefaId { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataCriacao { get; set; }

        public NaoIniciada NaoIniciada { get; set; }
        public EmAndamento EmAndamento { get; set; }
        public Terminada Terminada { get; set; }
    }
