using System.ComponentModel.DataAnnotations;

namespace _06_Entity.Models
{
    public class Product
    {
        public Product()
        {
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = String.Empty;
        [Required]
        [DataType(DataType.Currency)]
        public double Prix { get; set; }

        public Product(int id, string description, double prix)
        {
            Id = id;
            Description = description;
            Prix = prix;
        }
    }
}
