using System.IO;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    public int level = 1;
    public double currentExp = 0;
    public double expToNextLv = 100;

    private string savePath => Path.Combine(Application.persistentDataPath, "save.json");
    void Start()
    {
        LoadLevelData();
    }

    void Update()
    {
        
    }

    public void AddExp(int amount)
    {
        currentExp += amount;
        Debug.Log(currentExp);
        while(currentExp >= expToNextLv)
        {
            currentExp -= expToNextLv;
            LevelUp();
        }
    }

    public void LevelUp()
    {
        level++;
        expToNextLv = expToNextLv * 1.5f;
        Debug.Log("Level up! New level: " + level);
    }

    public void SaveLevelData()
    {
        PlayerSaveData data = new PlayerSaveData(this.level, this.currentExp, this.expToNextLv, null, null);
    }

    public void LoadLevelData()
    {
        PlayerSaveData data = SaveSystem.Load();
        if (data != null)
        {
                Debug.Log("Not found");
        }
        this.level = data.level;
        this.currentExp = data.experience;
        this.expToNextLv = data.expToNextLv;
        Debug.Log(level + " - " +  currentExp);

    }

    private void OnApplicationQuit()
    {
        SaveLevelData();
    }

}
