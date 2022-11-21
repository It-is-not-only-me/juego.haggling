using Haggling.Economia;

public partial class PruebasEconomia
{
    public class ValoracionTotalPrueba : IValoracion
    {
        private float _modificacion;

        public ValoracionTotalPrueba(float modificacion)
        {
            _modificacion = modificacion;
        }

        public IValor ValorarProducto(IProducto producto, IValor valorBase) => ValorarProducto(valorBase as ValorPrueba);

        private IValor ValorarProducto(ValorPrueba valorBase) => new ValorPrueba(valorBase.Valor + _modificacion);
    }
}
