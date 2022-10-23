using System.ComponentModel.DataAnnotations.Schema;

namespace PizzaStore.Models
{
    public class Pizza
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }
    }
}