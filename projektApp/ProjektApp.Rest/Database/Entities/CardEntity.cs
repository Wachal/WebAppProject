namespace ProjektApp.Rest.Database.Entities
{
    public class CardEntity
    {
        protected CardEntity()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public CardEntity(string cardNumber)
        {
            CardNumber = cardNumber;
        }

        public int CardEntryId {get; protected set;}

        public string CardNumber {get; protected set;}

        public DateTime CreatedOn {get; protected set;}
    }
}