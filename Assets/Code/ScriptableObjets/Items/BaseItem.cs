
using UnityEngine;

public class BaseItem : ScriptableObject
{
    [SerializeField] private string itemName;

    public string ItemName { get { return itemName; } }
}
