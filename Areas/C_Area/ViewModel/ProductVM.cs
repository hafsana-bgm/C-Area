using System.ComponentModel.DataAnnotations;

namespace C_Area.Areas.C_Area.ViewModel
{
    public class ProductVM
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
        public IFormFile? UploadImage { get; set; }
    }
}
