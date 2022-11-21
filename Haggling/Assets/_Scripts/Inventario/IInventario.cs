
using System.Collections.Generic;

namespace Haggling.Inventario
{
    public interface IInventario
    {
        public void AgregarElemento(ItIsNotOnlyMe.Inventario.IElemento elemento);
    }

    public class Inventario 
    {
        private ItIsNotOnlyMe.Inventario.IInventario _inventario;

        public Inventario() 
        {
            _inventario = new ItIsNotOnlyMe.Inventario.Inventario();
        }

        public void AgregarElemento(ItIsNotOnlyMe.Inventario.IElemento elemento)
        {
            throw new System.NotImplementedException();
        }   
    }

    public interface IEspacio : ItIsNotOnlyMe.Inventario.IEspacio
    {

    }

    public class EspacioUnico : IEspacio
    {
        private ItIsNotOnlyMe.Inventario.IElemento _elemento;

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion) => operacion.Aplicar(_elemento);

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion) => operacion.Aplicar(this);
    }

    public class EspacioStackeable : IEspacio
    {
        private List<ItIsNotOnlyMe.Inventario.IElemento> _elementos;
        private uint _cantidadMaxima;

        public EspacioStackeable(uint cantidadElementos)
        {
            _elementos = new List<ItIsNotOnlyMe.Inventario.IElemento>();
            _cantidadMaxima = cantidadElementos;
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion) => _elementos.ForEach(elemento => operacion.Aplicar(elemento));

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion) => operacion.Aplicar(this);
    }
}
