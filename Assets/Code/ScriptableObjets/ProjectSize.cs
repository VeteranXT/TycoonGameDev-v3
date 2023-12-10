using System;
using UnityEngine;

[CreateAssetMenu]
public class ProjectSize : ScriptableObject
{
    [SerializeField] private string sizeName;
    [SerializeField] private int minGameplayFeatures;
    [SerializeField] private int maxGameplayFeatures;
    [SerializeField] private Sprite sizeIcon;


    public string SizeName {  get { return sizeName; } }
    public int MinGameplayFeatures { get { return minGameplayFeatures; } }
    public int MaxGameplayFeatures { get { return maxGameplayFeatures; } }
    public Sprite SizeIco { get { return sizeIcon; } }
}