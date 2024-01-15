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
    class EscolherTipoDeEmissao
    {
      public static void escolhertipoemissao()
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
                    EmitirNotaFiscal.main();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    EmitirNotaFiscal.jsoninteiro();
                    break;

                case "0":
                    Console.WriteLine("Encerrando o programa...");
                    return;

            }
        }
    }
}
