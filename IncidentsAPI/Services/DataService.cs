using IncidentsAPI.Data;
using IncidentsAPI.DTOModels;
using IncidentsAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IncidentsAPI.Services
{
    public class DataService : IDataService
    {
        private readonly AppDbContext _dbContext;
        public DataService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContact(ContactDTO contactDto)
        {
            var contact = new Contact
            {
                Email = contactDto.Email,
                FirstName = contactDto.FirstName,
                LastName = contactDto.LastName
            };

            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateAccount(AccountDTO accountDto)
        {
            var account = new Account() { Name = accountDto.Name };
            account.Contacts = new List<Contact>();

            var dbContact = GetContactByEmail(accountDto.ContactEmail);
            if (dbContact != null)
            {
                UpdateContact(dbContact, accountDto.ContactFirstName, accountDto.ContactLastName, account);
            }
            else
            {
                dbContact = new Contact
                {
                    FirstName = accountDto.ContactFirstName,
                    LastName = accountDto.ContactLastName,
                    Email = accountDto.ContactEmail
                };
                _dbContext.Contacts.Add(dbContact);
            }

            account.Contacts.Add(dbContact);
            _dbContext.Accounts.Add(account);

            await _dbContext.SaveChangesAsync();
        }

        public async Task CreateIncident(IncidentDTO incidentDto)
        {
            var dbAccount = GetAccountByName(incidentDto.AccountName);

            Contact dbContact = GetContactByEmail(incidentDto.ContactEmail);
            if (dbContact != null)
            {
                UpdateContact(dbContact, incidentDto.ContactFirstName, incidentDto.ContactLastName, dbAccount);
            }
            else
            {
                Contact newContact = new Contact()
                {
                    Email = incidentDto.ContactEmail,
                    FirstName = incidentDto.ContactFirstName,
                    LastName = incidentDto.ContactLastName,
                    AccountName = dbAccount.Name
                };

                if (dbAccount.Contacts == null)
                    dbAccount.Contacts = new List<Contact>();

                dbAccount.Contacts.Add(newContact);
                _dbContext.Contacts.Add(newContact);
            }

            Incident incident = new Incident()
            {
                Description = incidentDto.Description
            };

            incident.Accounts = new List<Account>();
            incident.Accounts.Add(dbAccount);

            dbAccount.IncidentName = incident.Name;
            _dbContext.Incidents.Add(incident);

            await _dbContext.SaveChangesAsync();
        }

        private Contact GetContactByEmail(string email)
        {
            return _dbContext.Contacts.Find(email);
        }

        private Account GetAccountByName(string name)
        {
            return _dbContext.Accounts.Find(name);
        }

        private void UpdateContact(Contact contact, string firstName, string lastName, Account account)
        {
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Account = account;
        }

        public bool HasAccount(string name)
        {
            return _dbContext.Accounts.Any(a => a.Name == name);
        }
    }
}
