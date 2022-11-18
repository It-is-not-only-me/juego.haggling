using Economia;

public partial class PruebasEconomia
{
    public class ProductoPrueba : Producto
    {
        public enum CategoriaProducto
        {
            Hogar, 
            Pelea,
            Estudio
        }

        public CategoriaProducto Categoria { get; private set; }

        public ProductoPrueba(IValor valor, CategoriaProducto categoriaProducto) : base(valor)
        {
            Categoria = categoriaProducto;
        }
    }
}
