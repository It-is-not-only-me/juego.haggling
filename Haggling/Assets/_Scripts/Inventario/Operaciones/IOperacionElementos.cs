
namespace Haggling.Inventario
{
    public interface IOperacionElementos : ItIsNotOnlyMe.Inventario.IOperacionElementos
    {
        public void Aplicar(IElemento elemento);
    }
}
