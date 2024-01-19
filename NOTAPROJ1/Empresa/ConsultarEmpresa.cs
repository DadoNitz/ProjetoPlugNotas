using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NOTAPROJ1
{
    public class ConsultarEmpresa
    {
        public static async Task Consultarempresa(string apiUrl, string cnpj, string authToken)
        {
            string apiUrlEmpresa = $"{apiUrl}/empresa/{cnpj}";

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                try
                {
                    HttpResponseMessage response = await httpClient.GetAsync(apiUrlEmpresa);
                    if (response.IsSuccessStatusCode)
                    {
                        
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("==========> Dados da Empresa <==============");
                        Console.ResetColor();
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JsonBeautify(responseBody));
                    }
                    else
                    {
                        Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
                }
            }
        }

        public static async Task Main()
        {
            Console.Write("Informe o CNPJ da Empresa: ");
            string cnpj = Console.ReadLine();
            cnpj = Regex.Replace(cnpj, "[^0-9]+", "");


            string apiUrl = "https://api.sandbox.plugnotas.com.br";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            await Consultarempresa(apiUrl, cnpj, authToken);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        private static string JsonBeautify(string inputJson)
        {
            dynamic parsedJson = Newtonsoft.Json.JsonConvert.DeserializeObject(inputJson);
            return Newtonsoft.Json.JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
        }
    }
}
