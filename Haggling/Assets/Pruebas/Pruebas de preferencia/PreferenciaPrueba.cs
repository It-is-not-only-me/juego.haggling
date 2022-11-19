using Preferencia;

public partial class PruebasPreferencia
{
    public class PreferenciaPrueba : IPreferencia
    {
        private ICaracteristica _caracteristica;
        private float _modificacion;

        public PreferenciaPrueba(ICaracteristica caracteristica, float modificacion)
        {
            _caracteristica = caracteristica;
            _modificacion = modificacion;
        }

        public IValor Valorar(ICaracteristica caracteristica, IValor valorBase) => Valorar(caracteristica, valorBase as ValorPrueba);

        public IValor Valorar(ICaracteristica caracteristica, ValorPrueba valorBase)
        {
            float nuevoValor = valorBase.Valor;
            if (_caracteristica.EsIgual(caracteristica))
                nuevoValor += _modificacion;
            return new ValorPrueba(nuevoValor);
        }
    }
}
