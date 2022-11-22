
namespace Haggling.Inventario
{
    public class OperadorAgregarElemento : OperacionEspacios
    {
        private IEspacio _espacioAAgregar;
        private IElemento _elementoAgregar;
        private bool _sePudoAgregar;

        public OperadorAgregarElemento(IElemento elementoAgregar, IEspacio espacioAAgregar)
        {
            _espacioAAgregar = espacioAAgregar;
            _elementoAgregar = elementoAgregar;
            _sePudoAgregar = false;
        }

        /// <summary>
        ///     Va intentando agregar un elemento en algun espacio
        /// </summary>
        /// <param name="espacio"></param>
        public override void Aplicar(IEspacio espacio)
        {
            if (_sePudoAgregar || !EspacioBuscado(espacio))
                return;

            _sePudoAgregar = espacio.AgregarElemento(_elementoAgregar);
        }

        private bool EspacioBuscado(IEspacio espacio)
        {
            if (_espacioAAgregar == null)
                return true;
            return espacio.Equals(_espacioAAgregar);
        }

        public bool SePudoCompletar() => _sePudoAgregar;
    }
}
