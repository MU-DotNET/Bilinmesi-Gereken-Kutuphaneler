using System.ComponentModel.DataAnnotations;

namespace SwaggerApp.Models;

/// <summary>
/// Ürün Nesnesi
/// </summary>
public partial class Product
{
    /// <summary>
    /// Ürün id'si
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Ürün ismi
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Ürün fiyatı
    /// </summary>
    [Required]
    public decimal Price { get; set; }

    /// <summary>
    /// Ürün eklenme tarihi
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Ürün kategorisi
    /// </summary>
    public string? Category { get; set; }
}
