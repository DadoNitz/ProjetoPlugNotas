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
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear(); // Limpa a tela a cada iteração do menu

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.WriteLine("              Menu Principal                ");
                Console.WriteLine("============================================");
                Console.ResetColor();
                Console.WriteLine("1. Emitir Nota Fiscal");
                Console.WriteLine("2. Cadastrar Certificado ");
                Console.WriteLine("3. Cadastrar Empresa");
                Console.WriteLine("0. Sair");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.ResetColor();

                Console.Write("Opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        escolhertipoemissao();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=======> Cadastrando Certificado <==========");
                        Console.ResetColor();
                        CadastroCertificado();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=========> Cadastrando Empresa <============");
                        Console.ResetColor();
                        CadastrarEmpresa();
                        break;
                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();


            }

            static void EmitirNotaFiscal()
            {
                {
                    Root objetoRoot = ObterDadosDoUsuario();

                    string json = JsonSerializer.Serialize(objetoRoot, new JsonSerializerOptions { WriteIndented = true });


                    string apiUrl = "https://api.sandbox.plugnotas.com.br/nfe";
                    string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

                    // Enviando o JSON para a API
                    EnviarJsonParaAPI(apiUrl, json, authToken);

                    Console.WriteLine("Dados coletados em formato JSON:");
                    Console.WriteLine("[");
                    Console.WriteLine(json);
                    Console.WriteLine("]");


                    Console.WriteLine("Pressione qualquer tecla para fechar o programa...");
                    Console.ReadKey();
                }

                static Root ObterDadosDoUsuario()
                {
                    Root objetoRoot = new Root();

                    Console.Write("Informe o idIntegracao: ");
                    objetoRoot.idIntegracao = Console.ReadLine();

                    Console.Write("Presencial (True/False): ");
                    objetoRoot.presencial = Convert.ToBoolean(Console.ReadLine());

                    Console.Write("Consumidor Final (True/False): ");
                    objetoRoot.consumidorFinal = Convert.ToBoolean(Console.ReadLine());

                    Console.Write("Informe a natureza: ");
                    objetoRoot.natureza = Console.ReadLine();


                    // Emitente
                    Console.Write("Informe o CPF/CNPJ do Emitente: ");
                    string cpfCnpjEmitente = Console.ReadLine();

                    objetoRoot.emitente = new Emitente
                    {
                        cpfCnpj = cpfCnpjEmitente
                    };

                    // Destinatário
                    Console.Write("Informe o CPF/CNPJ do Destinatário: ");
                    string cpfCnpjDestinatario = Console.ReadLine();

                    Console.Write("Informe a Razão Social do Destinatário: ");
                    string razaoSocialDestinatario = Console.ReadLine();

                    Console.Write("Informe o E-mail do Destinatário: ");
                    string emailDestinatario = Console.ReadLine();

                    Console.Write("Informe o Tipo de Logradouro do Endereço: ");
                    string tipoLogradouro = Console.ReadLine();

                    Console.Write("Informe o Logradouro do Endereço: ");
                    string logradouro = Console.ReadLine();

                    Console.Write("Informe o Número do Endereço: ");
                    string numeroEndereco = Console.ReadLine();

                    Console.Write("Informe o Bairro do Endereço: ");
                    string bairro = Console.ReadLine();

                    Console.Write("Informe o Código da Cidade: ");
                    string codigoCidade = Console.ReadLine();

                    Console.Write("Informe a Descrição da Cidade: ");
                    string descricaoCidade = Console.ReadLine();

                    Console.Write("Informe o Estado: ");
                    string estado = Console.ReadLine();

                    Console.Write("Informe o CEP: ");
                    string cep = Console.ReadLine();

                    // Criando instância do destinatário
                    objetoRoot.destinatario = new Destinatario
                    {
                        cpfCnpj = cpfCnpjDestinatario,
                        razaoSocial = razaoSocialDestinatario,
                        email = emailDestinatario,
                        endereco = new Endereco
                        {
                            tipoLogradouro = tipoLogradouro,
                            logradouro = logradouro,
                            numero = numeroEndereco,
                            bairro = bairro,
                            codigoCidade = codigoCidade,
                            descricaoCidade = descricaoCidade,
                            estado = estado,
                            cep = cep
                        }
                    };

                    // Itens
                    Console.Write("Informe o Código do Item: ");
                    string codigoItem = Console.ReadLine();

                    Console.Write("Informe a Descrição do Item: ");
                    string descricaoItem = Console.ReadLine();

                    Console.Write("Informe o NCM do Item: ");
                    string ncmItem = Console.ReadLine();

                    Console.Write("Informe o CEST do Item: ");
                    string cestItem = Console.ReadLine();

                    Console.Write("Informe o CFOP do Item: ");
                    string cfopItem = Console.ReadLine();

                    Console.Write("Informe o Valor Unitário Comercial do Item: ");
                    double valorUnitarioComercialItem = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Informe o Valor Unitário Tributável do Item: ");
                    double valorUnitarioTributavelItem = Convert.ToDouble(Console.ReadLine());

                    Console.Write("Informe o Valor Total do Item: ");
                    double valorTotalItem = Convert.ToDouble(Console.ReadLine());

                    // Criando instância do item
                    objetoRoot.itens = new List<Item>
        {
            new Item
            {
                codigo = codigoItem,
                descricao = descricaoItem,
                ncm = ncmItem,
                cest = cestItem,
                cfop = cfopItem,
                valorUnitario = new ValorUnitario
                {
                    comercial = valorUnitarioComercialItem,
                    tributavel = valorUnitarioTributavelItem
                },
                valor = valorTotalItem,
                tributos = new Tributos
                {
                    icms = new ICMS
                    {
                        origem = "0",
                        cst = "00",
                        baseCalculo = new BaseCalculo { modalidadeDeterminacao = 0, valor = 0 },
                        aliquota = 0,
                        valor = 0
                    },
                    pis = new PIS
                    {
                        cst = "99",
                        baseCalculo = new BaseCalculo { valor = 0, quantidade = 0 },
                        aliquota = 0,
                        valor = 0
                    },
                    cofins = new COFINS
                    {
                        cst = "07",
                        baseCalculo = new BaseCalculo { valor = 0 },
                        aliquota = 0,
                        valor = 0
                    }
                }
            }
        };

                    // Pagamentos
                    Console.Write("A vista? (True/False): ");
                    bool aVistaPagamento = Convert.ToBoolean(Console.ReadLine());

                    Console.Write("Informe o Meio de Pagamento: ");
                    string meioPagamento = Console.ReadLine();

                    Console.Write("Informe o Valor do Pagamento: ");
                    double valorPagamento = Convert.ToDouble(Console.ReadLine());

                    // Criando instância do pagamento
                    objetoRoot.pagamentos = new List<Pagamento>
        {
            new Pagamento { aVista = aVistaPagamento, meio = meioPagamento, valor = valorPagamento }
        };

                    // Responsável Técnico
                    Console.Write("Informe o CPF/CNPJ do Responsável Técnico: ");
                    string cpfCnpjResponsavelTecnico = Console.ReadLine();

                    Console.Write("Informe o Nome do Responsável Técnico: ");
                    string nomeResponsavelTecnico = Console.ReadLine();

                    Console.Write("Informe o E-mail do Responsável Técnico: ");
                    string emailResponsavelTecnico = Console.ReadLine();

                    Console.Write("Informe o DDD do Telefone do Responsável Técnico: ");
                    string dddTelefoneResponsavelTecnico = Console.ReadLine();

                    Console.Write("Informe o Número do Telefone do Responsável Técnico: ");
                    string numeroTelefoneResponsavelTecnico = Console.ReadLine();

                    // Criando instância do responsável técnico
                    objetoRoot.responsavelTecnico = new ResponsavelTecnico
                    {
                        cpfCnpj = cpfCnpjResponsavelTecnico,
                        nome = nomeResponsavelTecnico,
                        email = emailResponsavelTecnico,
                        telefone = new Telefone { ddd = dddTelefoneResponsavelTecnico, numero = numeroTelefoneResponsavelTecnico }
                    };

                    // Exibindo os dados
                    Console.WriteLine("Dados inseridos:");
                    Console.WriteLine($"CPF/CNPJ do Emitente: {objetoRoot.emitente.cpfCnpj}");
                    Console.WriteLine($"CPF/CNPJ do Destinatário: {objetoRoot.destinatario.cpfCnpj}");
                    Console.WriteLine($"Razão Social do Destinatário: {objetoRoot.destinatario.razaoSocial}");
                    Console.WriteLine($"E-mail do Destinatário: {objetoRoot.destinatario.email}");
                    Console.WriteLine($"Tipo de Logradouro do Endereço: {objetoRoot.destinatario.endereco.tipoLogradouro}");
                    Console.WriteLine($"Logradouro do Endereço: {objetoRoot.destinatario.endereco.logradouro}");
                    Console.WriteLine($"Número do Endereço: {objetoRoot.destinatario.endereco.numero}");
                    Console.WriteLine($"Bairro do Endereço: {objetoRoot.destinatario.endereco.bairro}");
                    Console.WriteLine($"Código da Cidade: {objetoRoot.destinatario.endereco.codigoCidade}");
                    Console.WriteLine($"Descrição da Cidade: {objetoRoot.destinatario.endereco.descricaoCidade}");
                    Console.WriteLine($"Estado: {objetoRoot.destinatario.endereco.estado}");
                    Console.WriteLine($"CEP: {objetoRoot.destinatario.endereco.cep}");
                    Console.WriteLine($"Código do Item: {objetoRoot.itens[0].codigo}");
                    Console.WriteLine($"Descrição do Item: {objetoRoot.itens[0].descricao}");
                    Console.WriteLine($"NCM do Item: {objetoRoot.itens[0].ncm}");
                    Console.WriteLine($"CEST do Item: {objetoRoot.itens[0].cest}");
                    Console.WriteLine($"CFOP do Item: {objetoRoot.itens[0].cfop}");
                    Console.WriteLine($"Valor Unitário Comercial do Item: {objetoRoot.itens[0].valorUnitario.comercial}");
                    Console.WriteLine($"Valor Unitário Tributável do Item: {objetoRoot.itens[0].valorUnitario.tributavel}");
                    Console.WriteLine($"Valor Total do Item: {objetoRoot.itens[0].valor}");
                    Console.WriteLine($"À vista? {objetoRoot.pagamentos[0].aVista}");
                    Console.WriteLine($"Meio de Pagamento: {objetoRoot.pagamentos[0].meio}");
                    Console.WriteLine($"Valor do Pagamento: {objetoRoot.pagamentos[0].valor}");
                    Console.WriteLine($"CPF/CNPJ do Responsável Técnico: {objetoRoot.responsavelTecnico.cpfCnpj}");
                    Console.WriteLine($"Nome do Responsável Técnico: {objetoRoot.responsavelTecnico.nome}");
                    Console.WriteLine($"E-mail do Responsável Técnico: {objetoRoot.responsavelTecnico.email}");
                    Console.WriteLine($"Telefone do Responsável Técnico: ({objetoRoot.responsavelTecnico.telefone.ddd}) {objetoRoot.responsavelTecnico.telefone.numero}");

                    return objetoRoot;

                }
                static async Task EnviarJsonParaAPI(string apiUrl, string json, string authToken)
                {
                    using (HttpClient httpClient = new HttpClient())
                    {
                        // Configurando o cabeçalho de autorização
                        httpClient.DefaultRequestHeaders.Add("X-API-KEY", authToken);

                        // Literalmente só coloca colchetes no json para enviar como array de documento
                        string colchetesjson = $"[{json}]";

                        // Configurando o conteúdo da requisição como JSON
                        StringContent content = new StringContent(colchetesjson, Encoding.UTF8, "application/json");

                        try
                        {
                            // Enviando a requisição POST
                            HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                            // Verificando se a requisição foi bem-sucedida
                            if (response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("Nota(as) em processamento!");
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


            }

            static void escolhertipoemissao()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("=============> Emitindo NFe <===============");
                Console.ResetColor();
                Console.WriteLine("1. Inserir os Dados ");
                Console.WriteLine("2. Enviar JSON ");
                Console.WriteLine("0. Sair");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.ResetColor();

                Console.Write("Opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {

                    case "1":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("========> Insira os dados da NFe: <=========");
                        Console.ResetColor();
                        EmitirNotaFiscal();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============================================");
                        Console.ResetColor();
                        jsoninteiro();
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        return;

                }
            }
        }

            static async Task jsoninteiro()
        {
            Console.Write("Informe o caminho completo do arquivo JSON: ");
            string caminho = Console.ReadLine();

            if (File.Exists(caminho))
            {
                string json = File.ReadAllText(caminho, Encoding.UTF8);
                string apiUrl = "https://api.sandbox.plugnotas.com.br/nfe";
                string authToken = "2da392a6-79d2-4304-a8b7-959572c7e44d";

                await EnviarJsonParaAPI(apiUrl, json, authToken);
            }
            else
            {
                Console.WriteLine("Arquivo não encontrado. Certifique-se de fornecer o caminho correto.");
            }
        }

            static async Task EnviarJsonParaAPI(string apiUrl, string json, string authToken)
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
                        Console.WriteLine("Nota(as) em processamento!");
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

            static void CadastrarEmpresa()
            {
                EmpresaCadastro novaEmpresa = ColetarDadosEmpresaCadastro();
                ExibirDadosEmpresa(novaEmpresa);
                Console.WriteLine("Pressione qualquer tecla para fechar o programa...");
                Console.ReadKey();
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

                // Display the data in the console
                Console.WriteLine(JsonSerializer.Serialize(empresa, new JsonSerializerOptions { WriteIndented = true }));

                // Save the data to a JSON file
                SaveEmpresaCadastroToJsonFile(empresa);
            }

            static void SaveEmpresaCadastroToJsonFile(EmpresaCadastro empresa)
            {
                try
                {
                    string json = JsonSerializer.Serialize(empresa, new JsonSerializerOptions { WriteIndented = true });
                    System.IO.File.WriteAllText("empresa_data.json", json);
                    Console.WriteLine("Dados salvos em empresa_data.json");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao salvar os dados: {ex.Message}");
                }
            }
        
    }
}
    
