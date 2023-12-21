
using UnityEngine;

 public class Wall : MonoBehaviour
{
    [SerializeField] private MeshRenderer bottomWallRenderer;
    private bool isWall = false;
    public bool IsWall { get { return isWall; } set { isWall = value; } }
    private void Start()
    {
        bottomWallRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnValidate()
    {
        bottomWallRenderer = GetComponentInChildren<MeshRenderer>();
    }
}

