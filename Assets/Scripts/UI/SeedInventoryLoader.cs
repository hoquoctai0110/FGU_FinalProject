using UnityEngine;

public class SeedInventoryLoader : MonoBehaviour
{
    public SeedBarUI seedBarUI;
    void Start()
    {
        PlayerSaveData saveData = SaveSystem.Load();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ApplySeedInventory(PlayerSaveData saveData)
    {
        if (saveData.seedInventory == null) return;

        foreach (var item in saveData.seedInventory)
        {
            SeedData seed = seedBarUI.seedDataList.Find(s => s.seedName == item.seedId);
        }
        seedBarUI.RefreshSeedBar();
    }
}
