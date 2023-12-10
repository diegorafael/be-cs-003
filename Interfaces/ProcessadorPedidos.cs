namespace Interfaces
{
    internal class ProcessadorPedidos
    {
        public static Item[] Itens =
        {
            new Item(1, "Hamburguer de frango", 7),
            new Item(2, "Hamburguer bovino", 8),
            new Item(3, "Hamburguer vegano", 9),
            new Item(4, "Batata frita", 5),
            new Item(5, "Suco", 4),
            new Item(6, "Água", 3),
            new Item(7, "Refrigerante", 3),
            new Item(8, "Combo saudável (h. bovino + fritas + refri)", 16),
            new Item(9, "Arroz + Feijão + Ovo", 10)
        };

        Item[] ItensPedido = new Item[0];

        public void AdicionarPedido(int codigoItem)
        {

            ItensPedido = ItensPedido.Append(Itens[codigoItem - 1]).ToArray();
        }

        public decimal CalcularPedido()
            => ItensPedido.Sum(item => item.Valor);
    }
}
