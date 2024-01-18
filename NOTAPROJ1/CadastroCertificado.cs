using System;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;


namespace NOTAPROJ1
{
    class CadastroCertificado
    {
        public static void cadastrocertificado()
        {
            insercaodedados().Wait();
        }

        static async Task insercaodedados()
        {

            Console.Write("Informe o caminho completo do arquivo a ser enviado: ");
            string caminho = Console.ReadLine();

            Console.Write("Informe a senha do certificado: ");
            string senha = Console.ReadLine();

            await UploadFile(caminho, senha);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }

        static X509Certificate2 CarregarCertificado(string caminho, string senha)
        {
            try
            {
                // Tenta carregar o certificado do arquivo PFX (formato PKCS#12) com a senha
                X509Certificate2 certificado = new X509Certificate2(caminho, senha);
                return certificado;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao carregar o certificado: {ex.Message}");
                return null;
            }
        }

        static async Task UploadFile(string caminho, string senha)
        {
            X509Certificate2 certificado = CarregarCertificado(caminho, senha);

            if (certificado == null)
            {
                Console.WriteLine("Falha ao carregar o certificado. Verifique a senha e o arquivo.");
                return;
            }

            using (HttpClient httpClient = new HttpClient())
            using (MultipartFormDataContent form = new MultipartFormDataContent())
            {
                // Lê o arquivo como um array de bytes
                byte[] arquivoBytes = File.ReadAllBytes(caminho);

                // Adiciona o conteúdo do arquivo como ByteArrayContent
                ByteArrayContent byteArrayContent = new ByteArrayContent(arquivoBytes);
                form.Add(byteArrayContent, "ARQUIVO", Path.GetFileName(caminho));

                // Define o Content-Type como multipart/form-data
                form.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data");

                string certificadoUrl = "https://api.sandbox.plugnotas.com.br/certificado";

                string certificadoToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", certificadoToken);

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(certificadoUrl, form);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"{JsonBeautify(responseBody)}");
                    }
                    else
                    {
                        Console.WriteLine($"Erro no upload: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no upload: {ex.Message}");
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