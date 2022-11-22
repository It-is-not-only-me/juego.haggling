
namespace Haggling.Inventario
{
    public class EliminarElementoDelEspacio : OperacionEspacios
    {
        private IElemento _elementoAEliminar;
        private IEspacio _espacioDondeEliminar;
        private bool _pudoEliminar;

        public EliminarElementoDelEspacio(IElemento elementoAEliminar, IEspacio espacioDondeEliminar)
        {
            _elementoAEliminar = elementoAEliminar;
            _espacioDondeEliminar = espacioDondeEliminar;
            _pudoEliminar = false;
        }

        /// <summary>
        ///     Elimina el elemento del espacio, si este existe
        /// </summary>
        /// <param name="espacio"></param>
        public override void Aplicar(IEspacio espacio)
        {
            if (_pudoEliminar || !espacio.Equals(_espacioDondeEliminar))
                return;
            _pudoEliminar = espacio.EliminarElemento(_elementoAEliminar);
        }

        public bool SePudoCompletar() => _pudoEliminar;
    }
}
