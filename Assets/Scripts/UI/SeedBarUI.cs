using System.Collections.Generic;
using NUnit.Framework;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SeedBarUI : MonoBehaviour
{
    public GameObject seedButtonPrefab;
    public Transform contentPanel;
    public List<SeedData> seedDataList;

    private int selectedIndex = -1;
    private List<Button> buttonList = new List<Button>();
    void Start()
    {
        PopulateSeedBar();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 6; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (i < seedDataList.Count)
                {
                    SelectSeed(i);
                }
            }
        }
        UpdateButtonHighlight();
    }

    void PopulateSeedBar()
    {
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
            buttonList.Clear();
        }


        for (int i = 0; i < seedDataList.Count; i++)
        {
            int index = i;
            SeedData data = seedDataList[i];

            GameObject btnObj = Instantiate(seedButtonPrefab, contentPanel);
            btnObj.transform.GetComponent<Image>().sprite = data.icon;

            TMP_Text qtyText = btnObj.transform.Find("QuantityText").GetComponent<TMP_Text>();
            qtyText.text = data.quantity.ToString();

            TMP_Text indexText = btnObj.transform.Find("IndexText").GetComponent<TMP_Text>();
            indexText.text = (i+ 1).ToString();

            Button button = btnObj.GetComponent<Button>();
            button.onClick.AddListener(() => SelectSeed(index));
            buttonList.Add(button);
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

    public void RefreshSeedBar()
    {
        PopulateSeedBar();
    }

    void UpdateButtonHighlight()
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            ColorBlock colors = buttonList[i].colors;
            if (i == selectedIndex)
            {
                colors.normalColor = Color.yellow;
            }
            else
            {
                colors.normalColor = Color.white;
            }
            buttonList[i].colors = colors;
        }

    }
}
