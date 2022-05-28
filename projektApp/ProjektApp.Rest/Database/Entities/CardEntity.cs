namespace ProjektApp.Rest.Database.Entities
{
    public class CardEntity
    {
        
        public CardEntity(string cardNumber)
        {
            CardNumber = cardNumber;
            CreatedOn = DateTime.UtcNow.AddHours(2);
        }

        public int CardEntryId {get; protected set;}

        public string CardNumber {get; protected set;}

        public DateTime CreatedOn {get; protected set;}
    }
}