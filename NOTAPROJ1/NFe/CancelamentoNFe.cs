using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NOTAPROJ1
{
    public class CancelarNfe
    {
        public static async Task Main()
        {
            Console.Write("Informe o ID da Nota Fiscal: ");
            string idNota = Console.ReadLine();

            Console.Write("Justificativa: ");
            string reason = Console.ReadLine();

            string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/{idNota}/cancelamento";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            await CancelarNota(apiUrl, authToken, reason);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static async Task CancelarNota(string apiUrl, string authToken, string reason)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    var cancelamentoPayload = new { justificativa = reason };

                    var jsonPayload = Newtonsoft.Json.JsonConvert.SerializeObject(cancelamentoPayload);

                    var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JsonBeautify(responseBody));
                    }
                    else
                    {
                        Console.WriteLine($"Erro no cancelamento: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no cancelamento: {ex.Message}");
                }
            }
        }
        private static string JsonBeautify(string inputJson)
        {
            dynamic parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(inputJson);
            return Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
