
using UnityEngine;

public class BaseItem : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite icon;
    public string ItemName { get { return itemName; } }
    /// <summary>
    /// Icon sprite
    /// </summary>
    public Sprite GetIcon { get { return icon; } }
}
