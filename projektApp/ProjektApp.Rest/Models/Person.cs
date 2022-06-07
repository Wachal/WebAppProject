namespace ProjektApp.Rest.Models
{
    public class CreatePersonRequest
    {
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string CardNumber {get; set;}
        public bool IsWorking {get; set;}

        public bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName);
        }
    }
}