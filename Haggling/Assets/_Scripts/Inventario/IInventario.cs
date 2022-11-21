
namespace Haggling.Inventario
{
    public interface IInventario : ItIsNotOnlyMe.Inventario.IInventario
    {
        /// <summary>
        ///     Agrega un elemento al inventario, en la posicion que pueda
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns>Devuelve true si pudo agregar el objeto</returns>
        public bool AgregarElemento(IElemento elemento);

        /// <summary>
        ///     Agrega un elemento en un espacio especifico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="espacio"></param>
        /// <returns>Devuelve true si pudo eliminarlo</returns>
        public bool AgregarElemento(IElemento elemento, IEspacio espacio);

        /// <summary>
        ///     Elimina un elemento que esta en el inventario, en un espacio especifico
        /// </summary>
        /// <param name="elemento"></param>
        /// <param name="espacio"></param>
        /// <returns>Devuelve true si pudo eliminarlo</returns>
        public bool EliminarElemento(IElemento elemento, IEspacio espacio);
    }
}
