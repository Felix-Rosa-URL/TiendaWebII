using System.ComponentModel.DataAnnotations;

namespace TiendaWeb.Models;

public class Producto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El nombre es obligatorio")]
    [StringLength(100, MinimumLength = 3)]
    public string Nombre { get; set; } = "";

    [Required(ErrorMessage = "La descripción es obligatoria")]
    public string Descripcion { get; set; } = "";

    [Required]
    [Range(1,100000)]
    public decimal Precio { get; set; }

    [Range(0,10000)]
    public int Stock { get; set; }

    [Required]
    [RegularExpression(@"^[A-Z]{3}-\d{4}$",
        ErrorMessage="Formato AAA-0000")]
    public string CodigoSku { get; set; } = "";

    public bool Activo { get; set; } = true;
}