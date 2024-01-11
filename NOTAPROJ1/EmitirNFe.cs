using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace NOTAPROJ1
{
    class EmitirNFe
    {
        static void EMITIRNFE()
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
}