using System.ComponentModel.DataAnnotations;

namespace C_Area.Areas.C_Area.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public int LabelId { get; set; }
        public bool IsActive { get; set; }
        public string? Category { get; set; }
    }
    public class Label
    {
        [Key]
        public int LabelId { get; set; }
        public string? LabelName { get; set; }
    }
}
