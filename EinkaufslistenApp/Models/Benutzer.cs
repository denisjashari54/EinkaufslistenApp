using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EinkaufslistenApp.Models
{
    public class Benutzer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Benutzername { get; set; } = string.Empty;

        [Required]
        public string Passwort { get; set; } = string.Empty;

        public ICollection<EinkaufsItem> EinkaufsItems { get; set; }
    }
}
