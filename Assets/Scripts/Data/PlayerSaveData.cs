using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    public int level;
    public double experience;
    public double expToNextLv;
    public List<SeedInventoryItem> seedInventory = new();
    public List<MapTileData> mapData = new();
    public List<PlantData> plantData = new();

    public PlayerSaveData(int level, double currentExp, double expToNextLv, List<SeedInventoryItem> seeds, List<MapTileData> tiles)
    {
        this.level = level;
        this.experience = currentExp;
        this.expToNextLv = expToNextLv;
        this.seedInventory = seeds;
        this.mapData = tiles;
    }

    public PlayerSaveData() { }

    public int GetLevel()
    {
        return level;
    }

    public double GetExperience()
    {
        return experience;
    }

    public double GetExpToNextLv()
    {
        return expToNextLv;
    }
}

[System.Serializable]
public class SeedInventoryItem
{
    public string seedId;
    public int quantity;
}

[System.Serializable]
public class MapTileData
{
    public int x;
    public int y;
    public string tileType;
}

[System.Serializable]
public class PlantData
{
    public int x;
    public int y;
    public string seedId;
    public float growthTimer;
    public int currentStage;
}
