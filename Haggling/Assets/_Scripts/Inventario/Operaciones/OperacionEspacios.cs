
namespace Haggling.Inventario
{
    public abstract class OperacionEspacios : IOperacionEspacios
    {
        public void Aplicar(ItIsNotOnlyMe.Inventario.IEspacio espacio) => Aplicar(espacio as IEspacio);

        public abstract void Aplicar(IEspacio espacio);
    }
}
