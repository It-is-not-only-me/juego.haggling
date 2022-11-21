using NUnit.Framework;
using Haggling.Economia;

public partial class PruebasEconomia
{
    private const float _valorProducto = 10;
    private IValor _valorBase = new ValorPrueba(_valorProducto);

    [Test]
    public void Test01LaValoracionCompuestaSinValoracionesDevuelveElMismoValorBase()
    {
        IProducto espada = new ProductoPrueba(_valorBase, ProductoPrueba.CategoriaProducto.Pelea);
        IValoracion valoracionCompuesta = new ValoracionCompuesta();

        ValorPrueba valorEspada = espada.ValorDelProducto(valoracionCompuesta) as ValorPrueba;

        Assert.AreEqual(_valorProducto, valorEspada.Valor);
    }

    [Test]
    public void Test02LaValoracionCompuestaTieneUnaValoracionDevuelveElValorBaseModificado()
    {
        IProducto espada = new ProductoPrueba(_valorBase, ProductoPrueba.CategoriaProducto.Pelea);
        ValoracionCompuesta valoracionCompuesta = new ValoracionCompuesta();

        float valorModificador = 10;
        valoracionCompuesta.AgregarValoracion(new ValoracionTotalPrueba(valorModificador));

        ValorPrueba valorEspada = espada.ValorDelProducto(valoracionCompuesta) as ValorPrueba;

        Assert.AreEqual(_valorProducto + valorModificador, valorEspada.Valor);
    }

    [Test]
    public void Test03LaVacoracionCompuestaTieneMuchasValoracionesDevuelveElValorBaseModificado()
    {
        IProducto espada = new ProductoPrueba(_valorBase, ProductoPrueba.CategoriaProducto.Pelea);
        ValoracionCompuesta valoracionCompuesta = new ValoracionCompuesta();

        float valorModificador = 10;
        valoracionCompuesta.AgregarValoracion(new ValoracionTotalPrueba(valorModificador));

        float valorModificacionProductoIgual = 15;
        valoracionCompuesta.AgregarValoracion(new ValoracionSegunCategoriaPrueba(ProductoPrueba.CategoriaProducto.Pelea, valorModificacionProductoIgual));

        ValorPrueba valorEspada = espada.ValorDelProducto(valoracionCompuesta) as ValorPrueba;

        Assert.AreEqual(_valorProducto + valorModificador + valorModificacionProductoIgual, valorEspada.Valor);
    }

    [Test]
    public void Test04MismoProductoConDiferentesValoracionesTieneDiferentesValores()
    {
        IProducto espada = new ProductoPrueba(_valorBase, ProductoPrueba.CategoriaProducto.Pelea);
        ValoracionCompuesta valoracionFavorable = new ValoracionCompuesta();
        ValoracionCompuesta valoracionDesfavorable = new ValoracionCompuesta();

        float valorFavorable = 10, valorDesfavorable = 24;
        valoracionFavorable.AgregarValoracion(new ValoracionTotalPrueba(valorFavorable));
        valoracionDesfavorable.AgregarValoracion(new ValoracionTotalPrueba(valorDesfavorable));

        ValorPrueba valorEspadaFavorable = espada.ValorDelProducto(valoracionFavorable) as ValorPrueba;
        ValorPrueba valorEspadaDesfavorable = espada.ValorDelProducto(valoracionDesfavorable) as ValorPrueba;

        Assert.AreEqual(_valorProducto + valorFavorable, valorEspadaFavorable.Valor);
        Assert.AreEqual(_valorProducto + valorDesfavorable, valorEspadaDesfavorable.Valor);

        Assert.AreNotEqual(valorEspadaFavorable.Valor, valorEspadaDesfavorable.Valor);
    }

    [Test]
    public void Test05DiferentesProductosConLaMismaValoracionTienenElMismoValor()
    {
        float valorEspada = 100, valorLibro = 30;

        IProducto espada = new ProductoPrueba(new ValorPrueba(valorEspada), ProductoPrueba.CategoriaProducto.Pelea);
        IProducto libro = new ProductoPrueba(new ValorPrueba(valorLibro), ProductoPrueba.CategoriaProducto.Estudio);

        ValoracionCompuesta valoracionCompuesta = new ValoracionCompuesta();

        float valorModificacionIgual = 20, valorModificacionDiferente = -50;
        valoracionCompuesta.AgregarValoracion(new ValoracionSegunCategoriaPrueba(
            ProductoPrueba.CategoriaProducto.Estudio,
            valorModificacionIgual,
            valorModificacionDiferente
        ));

        ValorPrueba valorDeEspada = espada.ValorDelProducto(valoracionCompuesta) as ValorPrueba;
        ValorPrueba valorDeLibro = libro.ValorDelProducto(valoracionCompuesta) as ValorPrueba;

        Assert.AreEqual(valorDeEspada.Valor, valorDeLibro.Valor);
    }
}
