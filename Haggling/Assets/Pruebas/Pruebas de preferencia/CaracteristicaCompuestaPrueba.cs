using System.Collections.Generic;
using Preferencia;
using System.Linq;

public partial class PruebasPreferencia
{
    public class CaracteristicaCompuestaPrueba : ICaracteristica
    {
        private List<ICaracteristica> _caracteristicas;

        public CaracteristicaCompuestaPrueba(List<ICaracteristica> caracteristicas = null)
        {
            _caracteristicas = caracteristicas == null ? new List<ICaracteristica>() : caracteristicas;
        }

        public void AgregarCaracteristica(ICaracteristica caracteristica) => _caracteristicas.Add(caracteristica);

        public bool EsIgual(ICaracteristica caracteristica)
        {
            return (_caracteristicas.ToArray()).Any((caracteristicaActual) => caracteristicaActual.EsIgual(caracteristica));
        }
    }
}
