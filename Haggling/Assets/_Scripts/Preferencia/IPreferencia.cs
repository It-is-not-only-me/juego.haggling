namespace Preferencia
{
    public interface IPreferencia
    {
        public IValor Valorar(ICaracteristica caracteristica, IValor valorBase);
    }
}