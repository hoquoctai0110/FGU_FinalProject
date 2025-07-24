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
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if(x != 0 || y!= 0)
        {
            picking = new Vector2(x, y);
            lastPick = picking;
        }
        if (Input.GetMouseButtonDown(0))
        {
            AudioManager.Instance.PlayHoe();
            levelScript.AddExp(30);
         
                animator.SetFloat("pickX", lastPick.x);
                animator.SetFloat("pickY", lastPick.y);
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
            groundTilemap.SetTile(cellPos, null);
            soilTilemap.SetTile(cellPos, soilTile);
        }
    }
}
