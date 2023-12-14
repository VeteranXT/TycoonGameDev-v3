using UnityEngine;

public class Flaw : ScriptableObject
{
    [SerializeField] private string flawName;
    [SerializeField] private float flawChance;
    [Range(1,100f)]
    [Tooltip("How much this costs")]
    [SerializeField] private float flawCost;
}