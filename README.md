# test-task-incidents-api
API to create contacts, accounts, incidents

## Task description:

#### database structure

incidents -> accounts -> contacts         
incident -> account, 1=>M,        
account -> contact , 1=> M

Incident,  incident name - primary key, autogenerated, string   
Account, Name - > unique string field                       

#### create web api, asp core, ef code first 

methods to create, contacts, accounts, incidents          
account cannot be created without contact               
case cannot be created without account                    

#### logic for incident creation method

> request body                          
> {                                     
> account name,                         
> contact first name,                   
> contact last name,                    
> contact email, -> unique identifier,  
> incident description,               
> }                                     

if account name is not in the system, -> return 404                                   
if contact is in the system (check by email), update contact record, link to account if not linked        
if not, create new contact with first name, last name, email and link to the account         
create new case, for account and populate description               

## Notes:

Environment          
- Microsoft SQL Server    
- Asp.Net Core (3.1)    

To run locally:      
add appsettings.json with connectionString to database named "IncidentsConnection"

#### API endpoints:    
- /contact

Example of request body:
>{            
>	"Email": "test@test.com",     
>	"FirstName": "John",         
>	"LastName": "Smith"         
>}       

- /account

Example of request body:
>{     
> "Name": "account1",                   
>	"ContactEmail": "test@test.com",     
>	"ContactFirstName": "John",         
>	"ContactLastName": "Smith"         
>}    

- /incident

Example of request body:
>{      
> "AccountName": "account1",                  
>	"ContactFirstName": "Adam",         
>	"ContactLastName": "Smith"    
>	"ContactEmail": "test2@test.com",               
> "Description": "test description"                 
>}    










