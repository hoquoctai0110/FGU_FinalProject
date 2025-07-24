using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public SeedBarUI seedBarUI;
    public PlayerSaveData currentData = new();

    public Tilemap groundTilemap;
    public Tilemap soilTilemap;
    public TileBase soilTile;

    void Start()
    {
        LoadGame();
        ApplySeedInventoryToUI();
    }
    void SaveGame()
    {
        UpdateSeedInventoryFromUI();
        SaveMapData();
        SaveSystem.Save(currentData);
    }

    void LoadGame()
    {
        currentData = SaveSystem.Load();
        LoadMapData();
        Debug.Log("Game loaded. Seeds: " + currentData.seedInventory.Count);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    void ApplySeedInventoryToUI()
    {
        foreach (var seed in seedBarUI.seedDataList)
        {
            seed.quantity = 0;
        }

        foreach (var item in currentData.seedInventory)
        {
            SeedData seed = Resources.Load<SeedData>($"Seeds/{item.seedId}");
            if (seed != null)
            {
                SeedData clone = Instantiate(seed);
                clone.quantity = item.quantity;
                seedBarUI.seedDataList.Add(clone);
            }
            else
            {
                Debug.LogWarning("SeedData khoong ton tai: " + item.seedId);
            }
        }
        seedBarUI.RefreshSeedBar();
    }

    void UpdateSeedInventoryFromUI()
    {
        currentData.seedInventory.Clear();
        foreach (var seed in seedBarUI.seedDataList)
        {
            if (!string.IsNullOrEmpty(seed.seedName))
            {
                currentData.seedInventory.Add(new SeedInventoryItem
                {
                    seedId = seed.seedName,
                    quantity = seed.quantity
                });
            }
        }
    }

    void SaveMapData()
    {
        currentData.mapData.Clear();
        currentData.plantData.Clear();

        BoundsInt bounds = soilTilemap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            if(soilTilemap.GetTile(pos) == soilTile)
            {
                currentData.mapData.Add(new MapTileData
                {
                    x = pos.x,
                    y = pos.y,
                    tileType = "Soil"
                });
            }
        }

        Plant[] allPlants = Object.FindObjectsByType<Plant>(FindObjectsSortMode.None);
        foreach (var plant in allPlants)
        {
            Vector3Int cellPos = soilTilemap.WorldToCell(plant.transform.position);
            currentData.plantData.Add(new PlantData
            {
                x = cellPos.x,
                y = cellPos.y,
                seedId = plant.seedData.seedName,
                growthTimer = plant.seedData.growthTime,
                currentStage = plant.currentStage
            });
        }
    }

    void LoadMapData()
    {
        soilTilemap.ClearAllTiles();

        foreach (var tileData in currentData.mapData)
        {
            if (tileData.tileType == "Soil")
            {
                Vector3Int pos = new Vector3Int(tileData.x, tileData.y, 0);
                soilTilemap.SetTile(pos, soilTile);
            }
        }

        foreach (var plantData in currentData.plantData)
        {
            SeedData seed = Resources.Load<SeedData>($"Seeds/{plantData.seedId}");
            if (seed != null)
            {
                Vector3 plantPos = soilTilemap.GetCellCenterWorld(new Vector3Int(plantData.x, plantData.y, 0));
                GameObject plantObj = Instantiate(seed.plantPrefab, plantPos, Quaternion.identity);

                Plant plant = plantObj.GetComponent<Plant>();
                plant.seedData = seed;
                plant.seedData.growthTime = plantData.growthTimer;
            }
        }
    }

}
