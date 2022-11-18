
namespace Economia
{
    public interface IProducto
    {
        public IValor ValorDelProducto(IValoracion valoracion);
    }

    public class Producto : IProducto
    {
        protected IValor _valor;

        public Producto(IValor valor)
        {
            _valor = valor;
        }

        public IValor ValorDelProducto(IValoracion valoracion) => valoracion.ValorarProducto(this, _valor);
    }
}
