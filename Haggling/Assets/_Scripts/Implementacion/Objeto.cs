using Economia;
using Preferencia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : Producto
{
    protected List<ICaracteristica> _caracteristicas;

    public Objeto(Economia.IValor valor, List<ICaracteristica> caracteristicas = null) : base(valor)
    {
        _caracteristicas = caracteristicas == null ? new List<ICaracteristica>() : caracteristicas;
    }

    public void AgregarCaracteristica(ICaracteristica caracteristica) => _caracteristicas.Add(caracteristica);

    public Preferencia.IValor ValoracionSobrePreferencias(IPreferencia preferencia, Preferencia.IValor valorBase)
    {
        _caracteristicas.ForEach(caracteristica => valorBase = preferencia.Valorar(caracteristica, valorBase));
        return valorBase;
    }
}
