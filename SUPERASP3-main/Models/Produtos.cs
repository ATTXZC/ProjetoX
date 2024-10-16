        using System.ComponentModel.DataAnnotations;
        using System.ComponentModel.DataAnnotations.Schema;

        namespace Eco_life.Models
        {
            public class Produtos1
            {
                [Key]
                public int ID_Produtos { get; set; }

                [Required]
                [MaxLength(100)]
                public string Nome_Produto { get; set; } = "Produto Desconhecido";

                [Required]
                [MaxLength(100)]
                public string Categoria { get; set; } = "Categoria Desconhecida";

                [Required]
                public int Estoque { get; set; } = 0;

                [Required]
                [Range(0, 99999999.99)]
                [Column(TypeName = "decimal(10,2)")]
                public decimal preco_produto { get; set; } = 0.00M;

                [Required]
                [MaxLength(900)]
                public string descricao { get; set; } = "Sem Descrição";
            }
        }
