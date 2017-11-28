using System.ComponentModel.DataAnnotations;

namespace Vidbit.Models
{
    public class Genre
    {
        public byte Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}