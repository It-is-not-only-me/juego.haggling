using System;

namespace Haggling.Inventario
{
    public interface IEspacio : ItIsNotOnlyMe.Inventario.IEspacio
    {
        /// <summary>
        ///     Agrega el elemento en el mismo si este puede ser agregado en el mismo
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve true si pudo agregarlo</returns>
        public bool AgregarElemento(IElemento elemento);

        /// <summary>
        ///     Elimina un elemento del espacio
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve true si pudo eliminar el elemento del mismo</returns>
        public bool EliminarElemento(IElemento elemento);

        /// <summary>
        ///     Funcion que evalua en todos sus elemento una condicion
        /// </summary>
        /// <param name="condicion"></param>
        /// <returns>Devuelve true si algun elemento cumple la condicion y false si no tiene elementos o ninguno cumple la condicion</returns>
        public bool AlgunElementoCumple(Func<IElemento, bool> condicion = null);
    }
}
