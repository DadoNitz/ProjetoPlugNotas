using System;

namespace NOTAPROJ1
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.WriteLine("|             Menu Principal               |");
                Console.WriteLine("============================================");
                Console.ResetColor();
                Console.WriteLine("1. Notas");
                Console.WriteLine("2. Certificado ");
                Console.WriteLine("3. Empresa ");
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
                        Console.WriteLine("================> Notas <===================");
                        Console.ResetColor();
                        Console.WriteLine("1. Emitir NFe");
                        Console.WriteLine("2. Consultar cancelamento NFe");
                        Console.WriteLine("3. Cancelar NFe");
                        Console.WriteLine("4. Consultar NFe");
                        Console.WriteLine("5. Solicitar correcao de NFe");
                        Console.WriteLine("6. Consultar nota por periodo");
                        Console.WriteLine("0. Sair");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        Console.Write("Opção: ");
                        string select = Console.ReadLine();

                        switch (select)
                        {

                            case "1":
                                EscolherTipoDeEmissao.escolhertipoemissao();
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("======> Consultar cancelamento NFe <========");
                                Console.ResetColor();
                                ConsultarCancelamentoNFe.Main();
                                break;
                            case "3":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("=============> Cancelar NFe <===============");
                                Console.ResetColor();
                                CancelarNfe.Main();
                                break;
                            case "4":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("============> Consultar NFe <===============");
                                Console.ResetColor();
                                ConsultarNotaFiscal.Main();
                                break;
                            case "5":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("=======> Solicitar Correcao de NFe <========");
                                Console.ResetColor();
                                SolicitarCorrecaoDeNota.Main();
                                break;
                            case "6":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("=======> Solicitar correcao de NFe <========");
                                Console.ResetColor();
                                ConsultarNotaFiscalPorPeriodo.Main();
                                break;
                            case "0":
                                Console.WriteLine("Encerrando o programa...");
                                return;

                        }
                        break;

                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============> Certificados <================");
                        Console.ResetColor();
                        Console.WriteLine("1. Cadastrar certificado");
                        Console.WriteLine("2. Consultar certificado");
                        Console.WriteLine("0. Sair");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        Console.Write("Opção: ");
                        string Select = Console.ReadLine();

                        switch (Select)
                        {
                            case "1":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("========> Cadastrar certificado <==========");
                                Console.ResetColor();
                                CadastroCertificado.cadastrocertificado();
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("========> Consultar certificado <==========");
                                Console.ResetColor();
                                ConsultarCertificado.Main();
                                break;
                            case "0":
                                Console.WriteLine("Encerrando o programa...");
                                return;
                        }
                        break;

                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("===============> Empresa <==================");
                        Console.ResetColor();
                        Console.WriteLine("1. Cadastrar empresa");
                        Console.WriteLine("2. Consultar empresa");
                        Console.WriteLine("0. Sair");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============================================");
                        Console.ResetColor();

                        Console.Write("Opção: ");
                        string SELECT = Console.ReadLine();

                        switch (SELECT)
                        {
                            case "1":
                                EscolherTipoCadastro.escolhertipocadastro();
                                break;
                            case "2":
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("========> Consultar empresa <==========");
                                Console.ResetColor();
                                ConsultarEmpresa.Main();
                                break;
                            case "0":
                                Console.WriteLine("Encerrando o programa...");
                                return;
                        }
                        break;

                    case "0":
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}

