namespace ProjektApp.Rest.Database.Entities
{
    public class PersonEntity
    {
        protected PersonEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public PersonEntity(string firstName, string lastName, string cardNumber, bool isWorking)
        {
            FirstName = firstName;
            LastName = lastName;
            CardNumber = cardNumber;
            IsWorking = isWorking;
            CreatedOn = DateTime.UtcNow.AddHours(2);
        }

        public string FirstName {get; protected set;}

        public string LastName {get; protected set;}

        public string CardNumber {get; protected set;}

        public bool IsWorking {get; set;}

        public DateTime CreatedOn {get; protected set;}

    }
}