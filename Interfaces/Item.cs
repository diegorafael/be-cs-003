namespace Interfaces
{
    internal class Item
    {
        public int Codigo;
        public string Descricao;
        public decimal Valor;

        public Item(int codigo, string descricao, decimal valor)
        {
            Codigo = codigo;
            Descricao = descricao;
            Valor = valor;
        }
    }
}