using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint2.Models
{
    [Table("tb_Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        // Relacionamento 1:N entre Categoria e Receita
        public virtual ICollection<Receita> Receitas { get; set; }
    }
}
