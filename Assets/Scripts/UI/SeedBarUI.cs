using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class SeedBarUI : MonoBehaviour
{
    public GameObject seedButtonPrefab;
    public Transform contentPanel;
    public List<SeedData> seedDataList;

    private int selectedIndex = -1;
    void Start()
    {
        PopulateSeedBar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PopulateSeedBar()
    {

            for (int i = 0; i < seedDataList.Count; i++)
            {
                int index = i;
                SeedData data = seedDataList[i];

                GameObject btnObj = Instantiate(seedButtonPrefab, contentPanel);
                Image iconImage = btnObj.GetComponentInChildren<Image>();
                iconImage.sprite = data.icon;

                Button button = btnObj.GetComponent<Button>();
                button.onClick.AddListener(() => SelectSeed(index));
            }
    }

    void SelectSeed(int index)
    {
        selectedIndex = index;
        Debug.Log("Selected seed: " + seedDataList[index].seedName);
    }

    public SeedData GetSelectedSeed()
    {
        if (selectedIndex >= 0 && selectedIndex < seedDataList.Count)
        {
            return seedDataList[selectedIndex];
        }
        return null;
    }
}
