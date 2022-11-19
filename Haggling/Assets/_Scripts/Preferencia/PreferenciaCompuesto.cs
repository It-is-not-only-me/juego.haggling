using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Preferencia
{
    public class PreferenciaCompuesto : IPreferencia
    {
        protected List<IPreferencia> _preferencias;

        public PreferenciaCompuesto(List<IPreferencia> preferencias = null)
        {
            _preferencias = preferencias == null ? new List<IPreferencia>() : preferencias;
        }

        public void AgregarPreferencia(IPreferencia preferencia) => _preferencias.Add(preferencia);

        public IValor Valorar(ICaracteristica caracteristica, IValor valorBase)
        {
            IValor valorFinal = valorBase;
            _preferencias.ForEach(preferencia => valorFinal = preferencia.Valorar(caracteristica, valorFinal));
            return valorFinal;
        }
    }
}