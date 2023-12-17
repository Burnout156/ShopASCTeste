// Produto
using ShopASCLibrary.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Product
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Configuração para autoincremento
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    // Aqui utilizo ambas as propriedades para determinar o relacionamento com a tabela de Categoria
    public int CategoryId { get; set; }
    public Category Category { get; set; }
}
