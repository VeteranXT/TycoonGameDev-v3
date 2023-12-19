
using UnityEngine;

 public class Wall : MonoBehaviour
{
    [SerializeField] private MeshRenderer bottomWallRenderer;
    private Vector3 floorPos;
    public Vector3 Position { get { return this.floorPos; } }
    public bool hasWall = false;
    public bool hasDoor = false;
    public bool IsWall { get { return this.hasWall; } set { hasWall = value; } }
    private bool HasDoor { get { return hasDoor; } set { hasDoor = value; } }
    private void Start()
    {
        bottomWallRenderer = GetComponentInChildren<MeshRenderer>();
    }

    private void OnValidate()
    {
        bottomWallRenderer = GetComponentInChildren<MeshRenderer>();
    }
    public Wall(GameObject wallPrefab,Vector3 floorPos,CardinalDirection direction,Transform parent)
    {
        GameObject gm = Instantiate(wallPrefab, floorPos, Quaternion.Euler(0f, (int)direction * 90f, 0f), parent);
        Wall wall = gm.AddComponent<Wall>().GetComponent<Wall>();
        if(wall != null)
        {
            wall.transform.position = floorPos;
        }
    }
}

