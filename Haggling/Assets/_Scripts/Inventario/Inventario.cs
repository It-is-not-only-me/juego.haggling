using System.Collections.Generic;

namespace Haggling.Inventario
{
    public class Inventario : IInventario
    {
        private List<ItIsNotOnlyMe.Inventario.IEspacio> _espacios;
        private uint _capacidad;

        public Inventario(uint capacidad) 
        {
            _espacios = new List<ItIsNotOnlyMe.Inventario.IEspacio>();
            _capacidad = capacidad;
        }

        public bool AgregarElemento(IElemento elemento) => AgregarElemento(elemento, null);

        public bool AgregarElemento(IElemento elemento, IEspacio espacio)
        {
            OperadorAgregarElemento operacion = new OperadorAgregarElemento(elemento, espacio);
            AplicarOperacion(operacion);

            if (operacion.SePudoCompletar())
                return true;

            if (!SePuedeSumarEspacio())
                return false;

            IEspacio nuevoEspacio = elemento.EspacioNecesario();
            nuevoEspacio.AgregarElemento(elemento);
            AgregarEspacio(nuevoEspacio);
            return true;
        }

        public bool AgregarEspacio(ItIsNotOnlyMe.Inventario.IEspacio espacio)
        {
            _espacios.Add(espacio);
            return true;
        }

        public bool EliminarEspacio(ItIsNotOnlyMe.Inventario.IEspacio espacio)
        {
            return _espacios.Remove(espacio);
        }

        private bool SePuedeSumarEspacio() => CapacidadActual() < _capacidad;

        private uint CapacidadActual()
        {
            OperacionCapacidadEspacios operacion = new OperacionCapacidadEspacios();
            AplicarOperacion(operacion);
            return operacion.CapacidadTotal();
        }

        public bool EliminarElemento(IElemento elemento, IEspacio espacio)
        {
            EliminarElementoDelEspacio operacion = new EliminarElementoDelEspacio(elemento, espacio);
            AplicarOperacion(operacion);

            if (!operacion.SePudoCompletar())
                return false;

            if (!espacio.AlgunElementoCumple())
                EliminarEspacio(espacio);
            return true;
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionElementos operacion)
        {
            _espacios.ForEach(espacio => espacio.AplicarOperacion(operacion));
        }

        public void AplicarOperacion(ItIsNotOnlyMe.Inventario.IOperacionEspacios operacion)
        {
            _espacios.ForEach(espacio => espacio.AplicarOperacion(operacion));
        }
    }
}
