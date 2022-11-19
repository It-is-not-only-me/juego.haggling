using UnityEngine;
using Preferencia;

[CreateAssetMenu(fileName = "Categorizacion", menuName = "Haggeling/Categorizacion")]
public class CategorizacionSO : ScriptableObject, ICaracteristica
{
    public bool EsIgual(ICaracteristica caracteristica) => EsIgual(caracteristica as CategorizacionSO);

    private bool EsIgual(CategorizacionSO caracteristica) => caracteristica.Equals(this);
}
