namespace Haggling.Inventario
{
    public interface IElemento : ItIsNotOnlyMe.Inventario.IElemento
    {
        public IEspacio EspacioNecesario();

        public bool PuedeAgregarse(EspacioStackeable esapcio);

        public bool PuedeAgregarse(EspacioUnico espacio);
    }
}
