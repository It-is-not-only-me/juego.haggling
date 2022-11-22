using System;

namespace Haggling.Inventario
{
    public class EspacioUnico : IEspacio
    {
        private IElemento _elemento;

        public EspacioUnico()
        {
            _elemento = null;
        }

        public bool AgregarElemento(IElemento elemento)
        {
            if (_elemento != null || elemento.PuedeAgregarse(this))
                return false;

            _elemento = elemento;
            return true;
        }

        public bool AlgunElementoCumple(Func<IElemento, bool> condicion = null)
        {
            if (condicion == null)
                return _elemento != null;
            return condicion.Invoke(_elemento);            
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion) => operacion.Aplicar(_elemento);

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion) => operacion.Aplicar(this);

        public bool EliminarElemento(IElemento elemento)
        {
            if (_elemento == null || !elemento.EsIgual(_elemento))
                return false;
            
            _elemento = null;
            return true;
        }
    }
}
