using System;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace projekt
{
    class ApiController
    {
        public static bool callApi(string code, bool isWorking){
            Console.WriteLine(code);

            
            using (var client = new WebClient())
            {
                client.Headers[HttpRequestHeader.ContentType] = "application/json";

                CardEntrie odczyt = new CardEntrie(code, isWorking);

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var data = JsonSerializer.Serialize(odczyt, serializeOptions);

                // var result = client.UploadString("https://a-t-cloudcomputing.azurewebsites.net/CardEntries", "POST", data);
                 var result = client.UploadString("https://localhost:7234/CardEntries", "POST", data);
                Console.WriteLine(result);
            }
            
            return true;
        }
    }
}


