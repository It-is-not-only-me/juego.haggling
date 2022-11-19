using Preferencia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreferenciaSobreObjeto : IPreferencia
{
    private ICaracteristica _caracteristicaIndicadora;
    private int _modificacion;

    public PreferenciaSobreObjeto(ICaracteristica caracteristicaIndicadora, int modificacion)
    {
        _caracteristicaIndicadora = caracteristicaIndicadora;
        _modificacion = modificacion;
    }

    public IValor Valorar(ICaracteristica caracteristica, IValor valorBase) => Valorar(caracteristica, valorBase as Valor);

    private IValor Valorar(ICaracteristica caracteristica, Valor valorBase)
    {
        uint nuevoValor = valorBase.ValorActual();

        if (_caracteristicaIndicadora.EsIgual(caracteristica))
            nuevoValor = (uint)Mathf.Max(0, nuevoValor + _modificacion);

        return new Valor(nuevoValor);
    }
}
