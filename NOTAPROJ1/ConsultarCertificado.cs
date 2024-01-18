using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NOTAPROJ1
{
    public class ConsultarCertificado
    {
        public static async Task Main()
        {
            Console.Write("Informe o ID do certificado: ");
            string idCertificado = Console.ReadLine();

            string apiUrl = $"https://api.sandbox.plugnotas.com.br/certificado/{idCertificado}";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            await Consultarcertificado(apiUrl, authToken);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static async Task Consultarcertificado(string apiUrl, string authToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JsonBeautify(responseBody));
                    }
                    else
                    {
                        Console.WriteLine($"Erro na consulta: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na consulta: {ex.Message}");
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
