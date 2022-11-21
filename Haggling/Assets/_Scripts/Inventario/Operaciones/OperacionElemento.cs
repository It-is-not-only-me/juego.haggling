
namespace Haggling.Inventario
{
    public abstract class OperacionElemento : IOperacionElementos
    {
        public void Aplicar(ItIsNotOnlyMe.Inventario.IElemento elemento) => Aplicar(elemento as IElemento);

        public abstract void Aplicar(IElemento elemento);
    }
}
