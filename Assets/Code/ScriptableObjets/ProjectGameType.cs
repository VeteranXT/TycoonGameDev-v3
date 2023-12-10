using UnityEngine;

[CreateAssetMenu]
public class ProjectGameType : ScriptableObject
{
    [SerializeField]private string projectTypeName;

    public string ProjectType { get {  return projectTypeName; } }
}