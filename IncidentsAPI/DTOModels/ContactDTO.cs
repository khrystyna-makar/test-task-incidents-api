using System.ComponentModel.DataAnnotations;

namespace IncidentsAPI.DTOModels
{
    public class ContactDTO
    {
        [EmailAddress]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
