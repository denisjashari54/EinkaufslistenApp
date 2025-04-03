using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EinkaufslistenApp.Models
{
    public class EinkaufsItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Menge { get; set; }

        [Required]
        public bool Gekauft { get; set; } = false;

        public DateTime ErstelltAm { get; set; } = DateTime.Now;

        [Timestamp]
        public byte[] RowVersion { get; set; }


        [ForeignKey("Benutzer")]
        public int BenutzerId { get; set; } 

        public Benutzer? Benutzer { get; set; }  

    }
}
