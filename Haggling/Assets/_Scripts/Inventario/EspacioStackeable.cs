using System;
using System.Collections.Generic;
using System.Linq;

namespace Haggling.Inventario
{
    public class EspacioStackeable : IEspacio
    {
        private List<IElemento> _elementos;
        private uint _cantidadMaxima;

        public EspacioStackeable(uint cantidadElementos)
        {
            _elementos = new List<IElemento>();
            _cantidadMaxima = cantidadElementos;
        }

        public bool AgregarElemento(IElemento elemento)
        {
            if (!PuedeAgregarElemento(elemento) || elemento.PuedeAgregarse(this))
                return false;

            _elementos.Add(elemento);
            return true;
        }

        private bool PuedeAgregarElemento(IElemento elemento)
        {
            return _elementos.Any() && elemento.EsIgual(ElementoRepresentativo()) && _elementos.Count < _cantidadMaxima;
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion) => _elementos.ForEach(elemento => operacion.Aplicar(elemento));

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion) => operacion.Aplicar(this);

        public bool EliminarElemento(IElemento elemento)
        {
            if (!AlgunElementoCumple() || !elemento.EsIgual(ElementoRepresentativo()))
                return false;

            _elementos.RemoveAt(0);
            return true;
        }

        public bool AlgunElementoCumple(Func<IElemento, bool> condicion = null)
        {
            if (condicion == null)
                condicion = TieneElementos;
            bool algunoCumple = false;
            _elementos.ForEach(elemento => algunoCumple |= condicion.Invoke(elemento));
            return algunoCumple;
        }

        private IElemento ElementoRepresentativo() => _elementos.Any() ? _elementos[0] : null;

        private bool TieneElementos(IElemento elemento) => true;
    }
}
