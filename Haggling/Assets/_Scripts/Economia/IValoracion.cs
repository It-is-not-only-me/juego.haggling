namespace Economia
{
    public interface IValoracion
    {
        public IValor ValorarProducto(IProducto producto, IValor valorBase);
    }
}
