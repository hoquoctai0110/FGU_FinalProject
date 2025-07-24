using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerInteract : MonoBehaviour
{
    public Tilemap groundTilemap;
    public Tilemap soilTilemap;
    public TileBase grassTile;
    public TileBase soilTile;

    public Vector2 picking;
    public Vector2 lastPick = Vector2.zero;

    private Animator animator;

    public Transform toolPoint;

    public Transform playerTransform;

    public PlayerLevel levelScript;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Picking();
    }

    public void Picking()
    {
        if (Input.GetMouseButtonDown(0))
        {
            levelScript.AddExp(30);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePos);
            mousePos.z = 0;
            Vector2 pickPosition = (mousePos - playerTransform.position).normalized;
            animator.SetFloat("pickX", pickPosition.x);
            animator.SetFloat("pickY", pickPosition.y);
            animator.SetTrigger("picking");
        }
    }

    public void changeTile()
    {
        Vector3 worldPos = toolPoint.position;
        Vector3Int cellPos = groundTilemap.WorldToCell(worldPos);

        TileBase currentTile = groundTilemap.GetTile(cellPos);
        if (currentTile != null && currentTile.name.Contains("Grass"))
        {
            groundTilemap.SetTile(cellPos, soilTile);
        }
    }
}
