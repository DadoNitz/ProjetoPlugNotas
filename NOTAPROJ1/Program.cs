using System;

namespace NOTAPROJ1
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear(); // Limpa a tela a cada iteração do menu

                Console.WriteLine("Escolha uma opção:");
                Console.WriteLine("1. Emitir Nota Fiscal");
                Console.WriteLine("2. Cadastrar Empresa");
                Console.WriteLine("3. Sair");

                Console.Write("Opção: ");
                string escolha = Console.ReadLine();

                switch (escolha)
                {
                    case "1":
                        EmitirNFeNotaFiscal();
                        break;
                    case "2":
                        Console.WriteLine("Cadastre sua empresa aqui");
                        break;
                    case "3":
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
