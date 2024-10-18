using Microsoft.VisualBasic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APICatalogo.Models
{
    [Table("Categorias")]

    public class Categoria //classe anêmica
    {   
        public Categoria()
        {
            Produtos = new Collection<Produto>();
        }
        
        [Key]

        public int Id { get; set; }

        [Required]
        [StringLength(80)]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemUrl { get; set; }

        [JsonIgnore]//para não ficar mostrando as informações de produto quando for cadastrar uma categoria no HttpPost/HttpPut do swagger
        public ICollection<Produto> Produtos { get; set; }

    }
}
