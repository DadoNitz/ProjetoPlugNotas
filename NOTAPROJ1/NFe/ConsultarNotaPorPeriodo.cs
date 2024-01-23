using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NOTAPROJ1
{
    public class ConsultarNotaFiscalPorPeriodo
    {
        public static async Task Main()
        {
            Console.Write("Informe o CPF/CNPJ da Empresa: ");
            string cpfCnpj = Console.ReadLine();

            Console.Write("Informe a data inicial (formato YYYY-MM-DD): ");
            string dataInicial = Console.ReadLine();

            Console.Write("Informe a data final (formato YYYY-MM-DD): ");
            string dataFinal = Console.ReadLine();

            string apiUrl = $"https://api.sandbox.plugnotas.com.br/nfe/consulta/periodo?cpfCnpj={cpfCnpj}&dataInicial={dataInicial}&dataFinal={dataFinal}";

            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            await ConsultarNotasPorPeriodo(apiUrl, authToken);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        public static async Task ConsultarNotasPorPeriodo(string apiUrl, string authToken)
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
                        Console.WriteLine($"Erro na requisição: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro na requisição: {ex.Message}");
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
