using Economia;
using Preferencia;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValoracionDeObjetos : IValoracion
{
    private IPreferencia _preferencia;

    public Economia.IValor ValorarProducto(IProducto producto, Economia.IValor valorBase)
    {
        return ValorarObjeto(producto as Objeto, valorBase as Valor);
    }

    public Valor ValorarObjeto(Objeto objeto, Valor valorBase)
    {
        return objeto.ValoracionSobrePreferencias(_preferencia, valorBase) as Valor;
    }
}
