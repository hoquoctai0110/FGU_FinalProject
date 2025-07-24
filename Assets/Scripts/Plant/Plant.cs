using UnityEngine;

public class Plant : MonoBehaviour
{
    public SeedData seedData;

    private SpriteRenderer spriteRenderer;
    private float growthTimer ;
    public int currentStage ;
    float stageDuration;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if(seedData != null && seedData.growthStages.Length > 0)
        {
            spriteRenderer.sprite = seedData.growthStages[0];
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGrowth();

    }

    public bool IsMature()
    {
        return currentStage == seedData.growthStages.Length-1;
    }

    public void Harvest()
    {
        if (IsMature())
        {
            Debug.Log($"Thu hoạch {seedData.seedName}");
            Destroy(gameObject);
        }
    }

    public void UpdateGrowth()
    {
        if (seedData == null || seedData.growthStages.Length == 0) return;
        growthTimer += Time.deltaTime;
        stageDuration = seedData.growthTime / (seedData.growthStages.Length - 1);
        int nextStage = Mathf.FloorToInt(growthTimer / stageDuration);
        if (nextStage > currentStage && nextStage < seedData.growthStages.Length)
        {
            currentStage = nextStage;
            spriteRenderer.sprite = seedData.growthStages[currentStage];
        }
    }
}
