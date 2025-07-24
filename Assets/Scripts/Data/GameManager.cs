using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerSaveData currentData = new();

    void Start()
    {
        LoadGame();
    }
    void SaveGame()
    {
        SaveSystem.Save(currentData);
    }

    void LoadGame()
    {
        currentData = SaveSystem.Load();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}
