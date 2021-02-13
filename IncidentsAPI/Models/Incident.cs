using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentsAPI.Models
{
    public class Incident
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "varchar(36)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Description { get; set; }
     
        public ICollection<Account> Accounts { get; set; }
    }
}