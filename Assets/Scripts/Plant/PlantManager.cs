using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantManager : MonoBehaviour
{
    public SeedBarUI seedBarUI;
    public TileBase soilTile;
    public Transform toolPoint;
    public Tilemap soilTilemap;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPlantSeed();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryHarvest();
        }
    }

    void TryPlantSeed()
    {
        SeedData selectedSeed = seedBarUI.GetSelectedSeed();
        if (selectedSeed == null)
        {
            Debug.Log("Chưa chọn hạt giống");
            return;
        }
        if (selectedSeed.quantity <= 0)
        {
            Debug.Log("Không còn hạt giống: " + selectedSeed.seedName);
            return;
        }
        Debug.Log(selectedSeed.plantPrefab);
        Vector3Int cellPos = soilTilemap.WorldToCell(toolPoint.position);
        TileBase tile = soilTilemap.GetTile(cellPos);
        Debug.Log(tile);

        if (tile == soilTile)
        {
            Debug.Log("Tile là soil, trồng cây");
            Vector3 plantPos = soilTilemap.GetCellCenterWorld(cellPos);
            GameObject plantObj = Instantiate(selectedSeed.plantPrefab, plantPos, Quaternion.identity);
            Plant plant = plantObj.GetComponent<Plant>();
            Debug.Log(plant);
            plant.seedData = selectedSeed;
            selectedSeed.quantity--;
            seedBarUI.RefreshSeedBar();
        } else
        {
            Debug.Log("Không đúng đất");
        }
    }

    void TryHarvest()
    {
        Collider2D hit = Physics2D.OverlapPoint(toolPoint.position);
        if (hit != null)
        {
            Plant plant = hit.GetComponent<Plant>();
            if (plant != null)
            {
                if (plant.IsMature())
                {
                    AudioManager.Instance.PlayHarvest();
                    plant.Harvest();
                    plant.seedData.quantity += 2;
                    seedBarUI.RefreshSeedBar();
                }
                else
                {
                    Debug.Log("Không thể thu hoạch");
                }
            }
        }
    }
     
}
