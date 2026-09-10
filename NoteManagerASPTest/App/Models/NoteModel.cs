using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Models
{
    [Table("Notes")]
    public class NoteModel
    {
        [Key] // Defines the Primary Key
        [Column("Id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(1000)]
        [Column("Text")]
        public string Text { get; set; }

        [Required]
        [Column("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
