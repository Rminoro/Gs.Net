using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint2.Models
{
    [Table("tb_Funcionario")]
    public class Funcionario
    {
        public int Id { get; set; }

        [DisplayName("nm_Nome")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [DisplayName("nm_Função")]
        [Required(ErrorMessage = "O campo Função é obrigatório.")]
        public string Função { get; set; }
    }
}
