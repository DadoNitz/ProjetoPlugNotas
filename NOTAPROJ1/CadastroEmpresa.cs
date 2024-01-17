using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;


namespace NOTAPROJ1
{
    class CadastroEmpresa
    {
        public static void main()
        {
            CadastrarEMPRESA().Wait();
        }

        static async Task CadastrarEMPRESA()
        {
            bool dadosCorretos = false;
            EmpresaCadastro novaEmpresa;

            do
            {
                novaEmpresa = ColetarDadosEmpresaCadastro();

                Console.WriteLine("Os dados inseridos estão corretos? 1|SIM 2|NAO");
                int escolhaRevisao = Convert.ToInt32(Console.ReadLine());

                if (escolhaRevisao == 1)
                {
                    dadosCorretos = true;
                }
                else if (escolhaRevisao == 2)
                {
                    Console.WriteLine("Por favor, insira os dados novamente.");
                }
                else
                {
                    Console.WriteLine("Opção inválida. Por favor, escolha 1 para SIM ou 2 para NAO.");
                }

            } while (!dadosCorretos);

            // Agora os dados foram confirmados como corretos, você pode enviá-los para a API.
            await EnviarDadosParaAPI(novaEmpresa);

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
        }
        static async Task EnviarDadosParaAPI(EmpresaCadastro empresa)
        {
            string apiUrl = "https://api.sandbox.plugnotas.com.br/empresa";
            string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

            try
            {
                string empresaJson = JsonSerializer.Serialize(empresa);

                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                    var content = new StringContent(empresaJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(apiUrl, content);

                    if (response.IsSuccessStatusCode)
                    {
                        bool dadosCorretos = false;
                        EmpresaCadastro novaEmpresa;

                        Console.WriteLine("Dados enviados com sucesso para a API! Deseja revisar? 1|SIM 2|NAO");
                        int escolhaRevisao = Convert.ToInt32(Console.ReadLine());

                        if (escolhaRevisao == 1)
                        {
                            dadosCorretos = true;
                        }

                    }
                    else
                    {
                        Console.WriteLine($"Erro ao enviar dados para a API. Código: {response.StatusCode}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro durante o envio para a API: {ex.Message}");
            }
        }

        static EnderecoEmpresa ColetarDadosEnderecoEmpresa()
        {
            EnderecoEmpresa endereco = new EnderecoEmpresa();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("========= Coletar Dados de Endereço ========");
            Console.ResetColor();
            Console.Write("Código do País: ");
            endereco.CodigoPais = Console.ReadLine();
            Console.Write("Descrição do País: ");
            endereco.DescricaoPais = Console.ReadLine();
            Console.Write("Tipo do Logradouro: ");
            endereco.TipoLogradouro = Console.ReadLine();
            Console.Write("Logradouro: ");
            endereco.Logradouro = Console.ReadLine();
            Console.Write("Numero: ");
            endereco.Numero = Console.ReadLine();
            Console.Write("Complemento: ");
            endereco.Complemento = Console.ReadLine();
            Console.Write("Tipo do bairro: ");
            endereco.TipoBairro = Console.ReadLine();
            Console.Write("Bairro: ");
            endereco.Bairro = Console.ReadLine();
            Console.Write("Código da cidade: ");
            endereco.CodigoCidade = Console.ReadLine();
            Console.Write("Descrição da cidade: ");
            endereco.DescricaoCidade = Console.ReadLine();
            Console.Write("Estado: ");
            endereco.Estado = Console.ReadLine();
            Console.Write("CEP: ");
            endereco.Cep = Console.ReadLine();

            return endereco;
        }

        static ConfigRPS ColetarDadosConfigRPS()
        {
            ConfigRPS configRPS = new ConfigRPS();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==== Coletar Dados de Configuração RPS ====");
            Console.ResetColor();
            Console.Write("Lote: ");
            configRPS.Lote = Convert.ToInt32(Console.ReadLine());

            configRPS.Numeracao = ColetarNumeracoesRPS();

            return configRPS;
        }

        static List<NumeracaoRPS> ColetarNumeracoesRPS()
        {
            List<NumeracaoRPS> numeracoes = new List<NumeracaoRPS>();

            Console.Write("Quantidade de Numeracoes RPS: ");
            int quantidade = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                NumeracaoRPS numeracao = new NumeracaoRPS();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($"==== Coletar Dados para Numeracao RPS {i + 1} ===");
                Console.ResetColor();
                Console.Write("Numero: ");
                numeracao.Numero = Convert.ToInt32(Console.ReadLine());

                Console.Write("Serie: ");
                numeracao.Serie = Console.ReadLine();

                Console.Write("Numeracao Atual: ");
                numeracao.NumeracaoAtual = Convert.ToInt32(Console.ReadLine());

                numeracoes.Add(numeracao);
            }

            return numeracoes;
        }

        static NumeracaoRPS ColetarDadosNumeracaoRPS()
        {
            NumeracaoRPS numeracaoRPS = new NumeracaoRPS();

            Console.WriteLine("=== Coletar Dados de NumeracaoRPS ===");
            Console.Write("Numero: ");
            numeracaoRPS.Numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Serie: ");
            numeracaoRPS.Serie = Console.ReadLine();

            Console.Write("Numeracao Atual: ");
            numeracaoRPS.NumeracaoAtual = Convert.ToInt32(Console.ReadLine());

            return numeracaoRPS;
        }

        static Integracao ColetarDadosIntegracao()
        {
            Integracao integracao = new Integracao();

            Console.Write("Ativo (true/false): ");
            integracao.Ativo = Convert.ToBoolean(Console.ReadLine());

            return integracao;
        }

        static EmailConfig ColetarDadosEmailConfig()
        {
            EmailConfig emailConfig = new EmailConfig();
            Console.Write("Envio de E-mail (true/false): ");
            emailConfig.Envio = Convert.ToBoolean(Console.ReadLine());
            return emailConfig;
        }

        static ConfigNFSe ColetarDadosConfigNFSe()
        {
            ConfigNFSe configNFSe = new ConfigNFSe();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("======== Coletar Dados de ConfigNFSe =======");
            Console.ResetColor();
            Console.Write("Producao (true/false): ");
            configNFSe.Producao = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Envio Limitado (true/false): ");
            configNFSe.EnvioLimitado = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Quantidade de Integracoes: ");
            int quantidadeIntegracoes = Convert.ToInt32(Console.ReadLine());
            configNFSe.Integracoes = new List<Integracao>();

            configNFSe.Rps = ColetarDadosConfigRPS();

            return configNFSe;
        }

        static ConfigDFe ColetarDadosConfigDFe()
        {
            ConfigDFe configDFe = new ConfigDFe();

            Console.Write("Primeiro NSU (true/false): ");
            configDFe.PrimeiroNsu = Convert.ToBoolean(Console.ReadLine());

            return configDFe;
        }

        static ConfigNFe ColetarDadosConfigNFe()
        {
            ConfigNFe configNFe = new ConfigNFe();

            // Coleta dados para ConfigDFe
            configNFe.Dfe = ColetarDadosConfigDFe();

            Console.Write("Modo de Produção (true/false): ");
            configNFe.Producao = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Impressão FCP (true/false): ");
            configNFe.ImpressaoFcp = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Impressão Partilha (true/false): ");
            configNFe.ImpressaoPartilha = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Versão Manual: ");
            configNFe.VersaoManual = Console.ReadLine();

            Console.Write("Versão Esquema: ");
            configNFe.VersaoEsquema = Console.ReadLine();

            // Coleta dados para Lista de NumeracaoDFe
            Console.Write("Quantidade de Numeracoes DFe: ");
            int quantidadeNumeracoes = Convert.ToInt32(Console.ReadLine());
            configNFe.Numeracao = new List<NumeracaoDFe>();

            for (int i = 0; i < quantidadeNumeracoes; i++)
            {
                NumeracaoDFe numeracao = ColetarDadosNumeracaoDFe();
                configNFe.Numeracao.Add(numeracao);
            }

            return configNFe;
        }

        static ConfigNFCe ColetarDadosConfigNFCe()
        {
            ConfigNFCe configNFCe = new ConfigNFCe();

            Console.Write("Modo de Produção (true/false): ");
            configNFCe.Producao = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Versão Manual: ");
            configNFCe.VersaoManual = Console.ReadLine();

            Console.Write("Versão Esquema: ");
            configNFCe.VersaoEsquema = Console.ReadLine();

            // Coleta dados para Lista de NumeracaoDFe
            Console.Write("Quantidade de Numeracoes DFe: ");
            int quantidadeNumeracoes = Convert.ToInt32(Console.ReadLine());
            configNFCe.Numeracao = new List<NumeracaoDFe>();

            for (int i = 0; i < quantidadeNumeracoes; i++)
            {
                NumeracaoDFe numeracao = ColetarDadosNumeracaoDFe();
                configNFCe.Numeracao.Add(numeracao);
            }

            return configNFCe;
        }

        static NumeracaoDFe ColetarDadosNumeracaoDFe()
        {
            NumeracaoDFe numeracaoDFe = new NumeracaoDFe();

            Console.Write("Número: ");
            numeracaoDFe.Numero = Convert.ToInt32(Console.ReadLine());

            return numeracaoDFe;
        }

        static EmpresaCadastro ColetarDadosEmpresaCadastro()
        {
            EmpresaCadastro empresaCadastro = new EmpresaCadastro();

            empresaCadastro.Endereco = ColetarDadosEnderecoEmpresa();

            empresaCadastro.NFSe = ColetarDadosConfigNFSe();

            empresaCadastro.NFe = ColetarDadosConfigNFe();

            empresaCadastro.NFCe = ColetarDadosConfigNFCe();

            Console.Write("Incentivo Fiscal (true/false): ");
            empresaCadastro.IncentivoFiscal = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Incentivador Cultural (true/false): ");
            empresaCadastro.IncentivadorCultural = Convert.ToBoolean(Console.ReadLine());

            Console.Write("CPF/CNPJ: ");
            empresaCadastro.CPFCNPJ = Console.ReadLine();

            Console.Write("Inscrição Municipal: ");
            empresaCadastro.InscricaoMunicipal = Console.ReadLine();

            Console.Write("Certificado: ");
            empresaCadastro.Certificado = Console.ReadLine();

            Console.Write("Razão Social: ");
            empresaCadastro.RazaoSocial = Console.ReadLine();

            Console.Write("Simples Nacional (true/false): ");
            empresaCadastro.SimplesNacional = Convert.ToBoolean(Console.ReadLine());

            Console.Write("Regime Tributário: ");
            empresaCadastro.RegimeTributario = Convert.ToInt32(Console.ReadLine());

            Console.Write("Regime Tributário Especial: ");
            empresaCadastro.RegimeTributarioEspecial = Convert.ToInt32(Console.ReadLine());

            return empresaCadastro;
        }

        static void ExibirDadosEmpresa(EmpresaCadastro empresa)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("=== Dados da Nova Empresa Cadastrada ===");
            Console.ResetColor();
            Console.WriteLine(JsonSerializer.Serialize(empresa, new JsonSerializerOptions { WriteIndented = true }));

        }
        public static async Task jsoninteiro()
        {
            Console.Write("Informe o caminho completo do arquivo JSON: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                string json = File.ReadAllText(caminho, Encoding.UTF8);
                string apiUrl = "https://api.sandbox.plugnotas.com.br/empresa";
                string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

                await EnviarJsonParaAPI(apiUrl, json, authToken);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado. Certifique-se de fornecer o caminho correto.");
            }
        }
        public static async Task EnviarJsonParaAPI(string apiUrl, string json, string authToken)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                // Configurando o conteúdo da requisição como JSON
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);


                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(JsonBeautify(responseBody));
                    }
                    else
                    {
                        Console.WriteLine($"Erro no cadastro: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro no cadastro: {ex.Message}");
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
