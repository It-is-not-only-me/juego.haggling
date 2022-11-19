using System.Collections.Generic;
using UnityEngine.Pool;
using System.Linq;

public class Valor : Economia.IValor, Preferencia.IValor, ItIsNotOnlyMe.SistemaDeTradeo.IValor
{
    private uint _valor;

    public Valor(uint valor)
    {
        _valor = valor;
    }

    public bool ValorMayor(ItIsNotOnlyMe.SistemaDeTradeo.IValor valor) => ValorMayor(valor as Valor);

    private bool ValorMayor(Valor valor) => _valor == valor._valor;

    public bool ValorMayor(List<ItIsNotOnlyMe.SistemaDeTradeo.IValor> valores)
    {
        List<Valor> nuevosValores = GenericPool<List<Valor>>.Get();
        nuevosValores.Clear();
        valores.ForEach(valor => nuevosValores.Add(valor as Valor));
        return ValorMayor(nuevosValores);
    }

    private bool ValorMayor(List<Valor> valores) => !(valores.ToArray()).Any(valor => valor.ValorMayor(this));
}
