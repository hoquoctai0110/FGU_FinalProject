using UnityEngine;

[CreateAssetMenu(fileName = "SeedData", menuName = "Scriptable Objects/SeedData")]
public class SeedData : ScriptableObject
{
    public string seedName;
    public Sprite icon;
    public GameObject plantPrefab;
    public float growthTime;
}
