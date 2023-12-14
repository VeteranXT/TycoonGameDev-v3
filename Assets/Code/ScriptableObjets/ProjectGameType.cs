using UnityEngine;

[CreateAssetMenu]
public class ProjectGameType : ScriptableObject
{
    private GameplayFeatures[] requiredFeature;

    public GameplayFeatures[] RequiredFeature { get { return requiredFeature; } }
}