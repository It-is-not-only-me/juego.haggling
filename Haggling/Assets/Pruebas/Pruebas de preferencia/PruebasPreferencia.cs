using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Preferencia;
using System.Net.Http.Headers;

public partial class PruebasPreferencia
{

    private const float _valorBase = 10;
    private IValor _valorPrueba = new ValorPrueba(_valorBase);
    private ICaracteristica _caracteristica = new CaracteristicaPrueba(CaracteristicaPrueba.Caracterizacion.Entretenimiento);

    [Test]
    public void Test01PreferenciaNoModificaElValorBaseAlNoCoincidirLaCaracteristica()
    {
        float modificador = 10;
        ICaracteristica caracterisica = new CaracteristicaPrueba(CaracteristicaPrueba.Caracterizacion.Herramienta);
        IPreferencia preferencia = new PreferenciaPrueba(caracterisica, modificador);

        ValorPrueba valorModificado = preferencia.Valorar(_caracteristica, _valorPrueba) as ValorPrueba;

        Assert.AreEqual(_valorBase, valorModificado.Valor);
    }

    [Test]
    public void Test02PreferenciaModificaElValorBaseAlCoincidirLaCaracteristica()
    {
        float modificador = 10;
        ICaracteristica caracterisica = new CaracteristicaPrueba(CaracteristicaPrueba.Caracterizacion.Entretenimiento);
        IPreferencia preferencia = new PreferenciaPrueba(caracterisica, modificador);

        ValorPrueba valorModificado = preferencia.Valorar(_caracteristica, _valorPrueba) as ValorPrueba;

        Assert.AreEqual(_valorBase + modificador, valorModificado.Valor);
    }
}
