using System;
using UnityEngine;

[CreateAssetMenu]
public class ProjectSize : ScriptableObject
{
    [SerializeField] private string sizeName;
    [SerializeField] private float sizeModifier;
    [SerializeField] private Sprite sizeIcon;


    public string SizeName {  get { return sizeName; } }
    public float SizeModifer { get { return sizeModifier; } }
    public Sprite SizeIco { get { return sizeIcon; } }
}