using Economia;

public partial class PruebasEconomia
{
    public class ValorPrueba : IValor
    {
        public float Valor { get; private set; }

        public ValorPrueba(float valor)
        {
            Valor = valor;
        }
    }
}
