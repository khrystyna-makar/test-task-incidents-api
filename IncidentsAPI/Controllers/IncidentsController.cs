using System.Threading.Tasks;
using IncidentsAPI.DTOModels;
using IncidentsAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace IncidentsAPI.Controllers
{
    [ApiController]
    [Route("")]
    public class IncidentsController : ControllerBase
    {
        private readonly ILogger<IncidentsController> _logger;
        private readonly IDataService _dataService;

        public IncidentsController(IDataService dataService,
            ILogger<IncidentsController> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        [Route("/ping")]
        public IActionResult Ping()
        {
            return Ok("The service is up and running");
        }

        [HttpPost]
        [Route("/incident")]
        public async Task<IActionResult> CreateIncident(IncidentDTO incidentDTO)
        {
            try
            {
                if (!_dataService.HasAccount(incidentDTO.AccountName))
                {
                    return NotFound();
                }

                await _dataService.CreateIncident(incidentDTO);
            }
            catch(DbUpdateException)
            {
                return BadRequest();
            }
            
            return Ok("Incident created");
        }

        [HttpPost]
        [Route("/contact")]
        public async Task<ActionResult> CreateContact(ContactDTO contact)
        {
            try
            {
                await _dataService.CreateContact(contact);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok("Contact created");
        }

        [HttpPost]
        [Route("/account")]
        public async Task<ActionResult> CreateAccount(AccountDTO accountDTO)
        {
            try
            {
                 await _dataService.CreateAccount(accountDTO);
            }
            catch (DbUpdateException)
            {
                return BadRequest();
            }

            return Ok("Account created");
        }

    }
}
