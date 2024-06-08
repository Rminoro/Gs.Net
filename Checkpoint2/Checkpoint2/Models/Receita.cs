using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Checkpoint2.Models
{
    [Table("tb_Receita")]
    public class Receita
    {
        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }

        // Chave estrangeira para Categoria
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
