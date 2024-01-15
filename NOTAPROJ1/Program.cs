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
       public static void Main()
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
                        EscolherTipoDeEmissao.escolhertipoemissao();
                        break;
                    case "2":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=======> Cadastrando Certificado <==========");
                        Console.ResetColor();
                        CadastroCertificado.cadastrocertificado();
                        break;
                    case "3":
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("=========> Cadastrando Empresa <============");
                        Console.ResetColor();
                        CadastroEmpresa.cadastroempresa();
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
        }
    }
}
    
