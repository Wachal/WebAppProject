using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace projekt
{
    class ApiController
    {

        public static bool callApi(string code){
            Console.WriteLine(code);
            
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                CardEntrie odczyt = new CardEntrie(code);

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var data = JsonSerializer.Serialize(odczyt, serializeOptions);

                var response = client.UploadString("https://atcloudcomputing.azurewebsites.net/CardEntries", "POST", data);

                People? person = JsonSerializer.Deserialize<People>(response);

                return person.isWorking;
            }
            
        }

    }
}