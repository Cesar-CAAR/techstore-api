using System.ComponentModel.DataAnnotations.Schema;

namespace TechStoreAPI.Models
{
    [Table("componentes")]
    public class Componente
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; } = string.Empty;

        [Column("categoria")]
        public string Categoria { get; set; } = string.Empty;

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("stock")]
        public int Stock { get; set; }

        [Column("especificaciones")]
        public string? Especificaciones { get; set; }
    }
}