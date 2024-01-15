using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Security.Cryptography.X509Certificates;


namespace NOTAPROJ1
{
    class CadastroCertificado
    {
      public static void cadastrocertificado()

        {
            static async Task CadastroCertificado()
            {
                Console.Write("Informe o caminho completo do arquivo a ser enviado: ");
                string caminho = Console.ReadLine();

                Console.Write("Informe a senha do certificado: ");
                string senha = Console.ReadLine();

                await UploadFile(caminho, senha);
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
                            Console.WriteLine("Upload de arquivo bem-sucedido!");
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
        }
    }
}
