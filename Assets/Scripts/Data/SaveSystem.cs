using System.IO;
using UnityEngine;

public class SaveSystem
{
    static string SavePath => Path.Combine(Application.persistentDataPath, "save.json");

    public static void Save(PlayerSaveData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(SavePath, json);
        Debug.Log("Saved to: " + SavePath);
    }

    public static PlayerSaveData Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("No save file found");
            return new PlayerSaveData();
        }
        string json = File.ReadAllText(SavePath);
        return JsonUtility.FromJson<PlayerSaveData>(json);
    }

    public static void DeleteSave()
    {
        if (File.Exists(SavePath))
        {
            File.Delete(SavePath);
        }
    }

}
