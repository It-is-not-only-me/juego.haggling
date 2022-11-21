
namespace Haggling.Inventario
{
    public interface IOperacionEspacios : ItIsNotOnlyMe.Inventario.IOperacionEspacios
    {
        public void Aplicar(IEspacio espacio);
    }
}
