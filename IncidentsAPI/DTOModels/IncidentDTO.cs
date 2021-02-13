using System.ComponentModel.DataAnnotations;

namespace IncidentsAPI.DTOModels
{
    public class IncidentDTO
    {
        public string AccountName { get; set; }
        public string Description { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

    }
}
