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

                People odczyt = new People("Arek", code, "123123123");

                var serializeOptions = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                var data = JsonSerializer.Serialize(odczyt, serializeOptions);

                var result = client.UploadString("https://a-t-cloudcomputing.azurewebsites.net/People/", "POST", data);
                Console.WriteLine(result);
            }
            
            return true;
        }
    }
}


