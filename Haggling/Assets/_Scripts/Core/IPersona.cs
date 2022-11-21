using System.Collections.Generic;
using IVinculo = ItIsNotOnlyMe.ComunicacionDinamica.IVinculo;
using IMensaje = ItIsNotOnlyMe.ComunicacionDinamica.IMensaje;

namespace Haggling.Core
{
    public interface IPersona : ItIsNotOnlyMe.SistemaDeTradeo.IPersona, ItIsNotOnlyMe.ComunicacionDinamica.IPersona
    {

    }

    public class Persona : IPersona
    {
        private Inventario.IInventario _inventario;
        private ItIsNotOnlyMe.ComunicacionDinamica.Persona _comunicacion;

        public void AgregarObjetos(ItIsNotOnlyMe.SistemaDeTradeo.IObjeto objeto) => _inventario.AgregarElemento(objeto as ItIsNotOnlyMe.Inventario.IElemento);



        public bool CrearVinculo(IVinculo vinculo) => _comunicacion.CrearVinculo(vinculo);

        public bool RomperVinculo(IVinculo vinculo) => _comunicacion.RomperVinculo(vinculo);

        public void MandarMensaje(IMensaje mensaje) => _comunicacion.MandarMensaje(mensaje);


        public ItIsNotOnlyMe.SistemaDeTradeo.IObjeto Exigir(ItIsNotOnlyMe.SistemaDeTradeo.IObjeto objeto)
        {
            throw new System.NotImplementedException();
        }

        public void SaldarDeuda(ItIsNotOnlyMe.SistemaDeTradeo.IDeuda deuda)
        {
            throw new System.NotImplementedException();
        }
    }
}
