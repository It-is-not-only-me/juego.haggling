using Preferencia;

public partial class PruebasPreferencia
{
    public class CaracteristicaPrueba : ICaracteristica
    {
        public enum Caracterizacion
        {
            Herramienta,
            Entretenimiento,
            Estudio
        }

        private Caracterizacion _caracterizacion;

        public CaracteristicaPrueba(Caracterizacion caracterizacion)
        {
            _caracterizacion = caracterizacion;
        }

        public bool EsIgual(ICaracteristica caracteristica) => EsIgual(caracteristica as CaracteristicaPrueba);

        private bool EsIgual(CaracteristicaPrueba caracteristica) => _caracterizacion == caracteristica._caracterizacion;
    }
}
