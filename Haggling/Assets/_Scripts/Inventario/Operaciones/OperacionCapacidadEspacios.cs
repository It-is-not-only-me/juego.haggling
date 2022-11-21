
namespace Haggling.Inventario
{
    public class OperacionCapacidadEspacios : OperacionEspacios
    {
        private uint _capacidad;

        public OperacionCapacidadEspacios()
        {
            _capacidad = 0;
        }

        public override void Aplicar(IEspacio espacio) => _capacidad++;

        public uint CapacidadTotal() => _capacidad;
    }
}
