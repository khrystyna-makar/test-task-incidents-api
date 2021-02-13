using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentsAPI.Models
{
    public class Account
    {
        [Key]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }


        [ForeignKey("IncidentName")]
        public string IncidentName { get; set; }
        public Incident Incident { get; set; }
    }
}