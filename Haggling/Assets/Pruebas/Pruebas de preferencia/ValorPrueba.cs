using Haggling.Preferencia;

public partial class PruebasPreferencia
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
