using Economia;

public partial class PruebasEconomia
{
    public class ValoracionSegunCategoriaPrueba : IValoracion
    {
        private ProductoPrueba.CategoriaProducto _categoriaFavorita;
        private float _modificacionFavorecido, _modificacionDesfavorecido;

        public ValoracionSegunCategoriaPrueba(ProductoPrueba.CategoriaProducto categoriaFavorita, float modificacionFavorecido, float modificacionDesfavorecido = 0f)
        {
            _categoriaFavorita = categoriaFavorita;
            _modificacionFavorecido = modificacionFavorecido;
            _modificacionDesfavorecido = modificacionDesfavorecido;
        }

        public IValor ValorarProducto(IProducto producto, IValor valorBase) => ValorarProducto(producto as ProductoPrueba, valorBase as ValorPrueba);

        private IValor ValorarProducto(ProductoPrueba producto, ValorPrueba valorBase)
        {
            float valorNuevo = valorBase.Valor;
            valorNuevo += (producto.Categoria == _categoriaFavorita) ? _modificacionFavorecido : _modificacionDesfavorecido;
            return new ValorPrueba(valorNuevo);
        }
    }
}
