namespace ProjektApp.Rest.Models
{
    public class CreateCardRequest
    {
        public string CardNumber {get; set;}

        public bool Validate()
        {
            return !string.IsNullOrEmpty(CardNumber);
        }
    }
}