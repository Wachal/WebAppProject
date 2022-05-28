namespace ProjektApp.Rest.Database.Entities
{
    public class PersonEntity
    {
        protected PersonEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public PersonEntity(string firstName, string lastName, string cardNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
        }

        public int PersonId {get; protected set;}

        public string FirstName {get; protected set;}

        public string LastName {get; protected set;}

        public string CardNumber {get; protected set;}

        public DateTime CreatedOn {get; protected set;}
    }
}