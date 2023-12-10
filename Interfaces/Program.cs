using System.Drawing;

namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Caixa caixa = new Caixa();

            while (true)
            {
                ProcessadorPedidos processadorPedidos = new ProcessadorPedidos();
                Console.Clear();
                TextoEmCor("------- INICIO DO PEDIDO -------", ConsoleColor.Gray);
            
                while (true)
                {
                    ImprimirMenu();
                    Console.Write("Informe o código do item que deseja adicionar ao pedido. Para finalizar digite qualquer caracter não numérico: ");

                    if (int.TryParse(Console.ReadLine(), out int itemSelecionado))
                    {
                        processadorPedidos.AdicionarPedido(itemSelecionado);
                        Console.WriteLine("Item adicionado. Para finalizar digite 'FIM', para continuar pressione 'ENTER'.");
                        string? opcao = Console.ReadLine();

                        if(opcao?.Trim().ToLower() == "fim")
                        {
                            TextoEmCor("    -- Fim do pedido --    ", ConsoleColor.Gray);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            TextoEmCor("    --- CONTINUANDO PEDIDO ---    ", ConsoleColor.Gray);
                        }
                    }
                    else break;
                }

                Console.WriteLine();
                TextoEmCor($" ---> O Total do seu pedido é: {processadorPedidos.CalcularPedido()}", ConsoleColor.DarkGreen);

                if(processadorPedidos.CalcularPedido() > 0)
                {
                    Console.WriteLine();
                    Console.Write($"      Informe o valor que foi pago: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal valorPago))
                    {
                        decimal troco = valorPago - processadorPedidos.CalcularPedido() ;

                        if (troco < 0)
                        {
                            TextoEmCor($"QUANTIA INSUFICIENTE. PEDIDO CANCELADO.", ConsoleColor.Red);
                            Console.ReadLine();
                            continue;
                        }

                        if (troco > 0)
                            TextoEmCor($"Entregue o troco no valor de R$ {troco}", ConsoleColor.Yellow);

                        caixa.RegistrarPagamento(valorPago - troco);
                        TextoEmCor("Pagamento registrado.", ConsoleColor.Green);
                            
                        if (DesejaEncerrarCaixa())
                        {
                            TextoEmCor("    -- Caixa encerrado --    ", ConsoleColor.Gray);
                            break;
                        }
                    }
                    else 
                    {
                        TextoEmCor($"VALOR INVÁLIDO. PEDIDO CANCELADO.", ConsoleColor.Red);
                        Console.ReadLine();
                        continue;
                    }
                }
                else
                    if (DesejaEncerrarCaixa())
                    {
                        TextoEmCor("    -- Caixa encerrado --    ", ConsoleColor.Gray);
                        break;
                    }

                TextoEmCor("------- FIM DO PEDIDO -------", ConsoleColor.Gray);
            }

            TextoEmCor($"   O Total de vendas em {caixa.FormaPagamento} foi: R$ {caixa.CalcularVendas()}", ConsoleColor.Cyan);
        }

        private static void ImprimirMenu()
        {
            TextoEmCor("    *** MENU ***    ", ConsoleColor.DarkGray);
            Console.WriteLine(" Código -                        Descrição                        -    Valor ");
            for (int i = 0; i < ProcessadorPedidos.Itens.Length; i++) {
                Console.WriteLine($" {ProcessadorPedidos.Itens[i].Codigo} - {ProcessadorPedidos.Itens[i].Descricao.PadRight(64, '.')} R$ {ProcessadorPedidos.Itens[i].Valor}");
            }

            Console.WriteLine();
        }

        private static bool DesejaEncerrarCaixa()
        {
            Console.WriteLine("Para encerrar o dia digite 'FIM', para começar um novo pedido pressione 'ENTER'.");
            string? opcao = Console.ReadLine();

            return opcao?.Trim().ToLower() == "fim";
        }

        private static void TextoEmCor(string conteudo, ConsoleColor cor)
        {
            ConsoleColor anterior = Console.ForegroundColor;
            Console.ForegroundColor = cor;
            Console.WriteLine(conteudo);
            Console.ForegroundColor = anterior;
        }
    }
}