namespace Interfaces
{
    internal class Caixa
    {
        public string FormaPagamento = "DINHEIRO";
        decimal totalVendas = 0;

        public void RegistrarPagamento(decimal valor)
        {
            totalVendas += valor;
        }

        public decimal CalcularVendas() { 
            return totalVendas; 
        }
    }
}
