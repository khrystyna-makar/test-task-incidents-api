using IncidentsAPI.DTOModels;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public interface IDataService
    {      
        Task CreateContact(ContactDTO contact);
        Task CreateAccount(AccountDTO account);
        Task CreateIncident(IncidentDTO incident);
        bool HasAccount(string name);
    }
}
