using UnityEngine;

[System.Serializable]
public class PlayerLevelData
{
    private int level;
    private int currentExp;
    private int expToNextLevel;

    public PlayerLevelData(int level, int currentExp, int expToNextLevel)
    {
        this.level = level;
        this.currentExp = currentExp;
        this.expToNextLevel = expToNextLevel;
    }

    public void SetLevel(int level)
    {
        this.level = level;
    }

    public int GetLevel() { 
        return this.level;
    }

    public void SetCurrentExp(int currentExp) 
    {
        this.currentExp = currentExp;
    }

    public int GetCurrentExp()
    {
        return this.currentExp;
    }

    public void SetExpToNextLevel(int expToNextLevel)
    {
        this.expToNextLevel = expToNextLevel;
    }

    public int GetExpToNextLevel()
    {
        return this.expToNextLevel;
    }
    
}
