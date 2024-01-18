using System;

namespace NOTAPROJ1
{
    class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.Clear(); // Limpa a tela a cada iteração do menu
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.WriteLine("|             Menu Principal               |");
                Console.WriteLine("============================================");
                Console.ResetColor();
                Console.WriteLine("1. Emitir Nota Fiscal");
                Console.WriteLine("2. Cadastrar Certificado ");
                Console.WriteLine("3. Cadastrar Empresa");
                Console.WriteLine("4. Consultar Nota");
                Console.WriteLine("5. Consultar Empresa");
                Console.WriteLine("6. Cancelar NFe");
                Console.WriteLine("0. Sair");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("============================================");
                Console.ResetColor();

                Console.Write("Opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EscolherTipoDeEmissao.escolhertipoemissao();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=======> Cadastrando Certificado <==========");
                        Console.ResetColor();
                        CadastroCertificado.cadastrocertificado();
                        break;
                    case "3":
                        EscolherTipoCadastro.escolhertipocadastro();
                        break;
                    case "4":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("============> Consultar Nota <==============");
                        Console.ResetColor();
                        ConsultarNotaFiscal.Main();
                        break;
                    case "5":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=========> Consultar Empresa <==============");
                        Console.ResetColor();
                        ConsultarEmpresa.Main();
                        break;
                    case "6":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=========> Cancelamento de NFe <============");
                        Console.ResetColor();
                        CancelarNfe.Main();
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

