namespace ProjektApp.Rest.Models
{
    public class CreatePersonRequest
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber {get; set;}

//mozna dac jakąś validacje
        public bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName);
        }
    }
}