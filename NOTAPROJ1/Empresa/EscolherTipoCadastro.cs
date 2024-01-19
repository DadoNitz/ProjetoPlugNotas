using System;


namespace NOTAPROJ1
{
    class EscolherTipoCadastro
    {
        public static void escolhertipocadastro()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("==========> Cadastrar Empresa <=============");
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
                    CadastroEmpresa.main();
                    break;
                case "2":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("============================================");
                    Console.ResetColor();
                    CadastroEmpresa.jsoninteiro();
                    break;

                case "0":
                    Console.WriteLine("Encerrando o programa...");
                    return;
            }
        }
    }
}
