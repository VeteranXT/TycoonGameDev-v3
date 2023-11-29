using UnityEngine;

[CreateAssetMenu(fileName = "New Gameplay Feature", menuName = "Features/Gameplay Features/New Gameplay")]
public class GameplayFeatures : LockResearchables
{
    private float devPoints;
    private string featureName;

    public string FeatureName {  get { return featureName; } }
    public float DevPoints { get { return devPoints; } }
}