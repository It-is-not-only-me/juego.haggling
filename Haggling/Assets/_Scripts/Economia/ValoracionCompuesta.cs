
using System.Collections.Generic;

namespace Economia
{
    public class ValoracionCompuesta : IValoracion
    {
        private List<IValoracion> _valoradores;

        public ValoracionCompuesta(List<IValoracion> valoradores = null)
        {
            _valoradores = valoradores == null ? new List<IValoracion>() : valoradores;
        }

        public void AgregarValoracion(IValoracion valoracion) => _valoradores.Add(valoracion);

        public IValor ValorarProducto(IProducto producto, IValor valorBase)
        {
            IValor valorModificado = valorBase;
            _valoradores.ForEach((valoracion) => valorModificado = valoracion.ValorarProducto(producto, valorModificado));
            return valorModificado;
        }
    }
}
