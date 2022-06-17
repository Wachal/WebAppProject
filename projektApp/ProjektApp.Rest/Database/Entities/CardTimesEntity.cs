namespace ProjektApp.Rest.Database.Entities
{
    public class CardTimesEntity
    {
        public string CardNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int TimeInSeconds  { get; set; }

        public int TimeInMins {get;set;}

        public int TimeInHours {get;set;}
    }
}