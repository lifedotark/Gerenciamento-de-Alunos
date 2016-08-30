using System.ComponentModel.DataAnnotations;

namespace GerenciamentoAlunos.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        [Required]
        public int Ra { get; set; }

        [Required]
        [StringLength(255)]
        public string Nome { get; set; }

        [Required]
        [StringLength(255)]
        public string Cidade { get; set; }
    }
}