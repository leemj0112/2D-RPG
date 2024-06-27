using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreManager : MonoBehaviour
{
    public ItemData[] items;
    public GameObject Purchase_UI;
    public Image ItemImage;
    public Text ItemName;
    public Text ItemCoin;
    public Text ItemExplain;

    private Dictionary<string, ItemData> itemDictionary;

    void Start()
    {
        itemDictionary = new Dictionary<string, ItemData>();
        foreach (ItemData item in items)
        {
            itemDictionary[item.ItemID] = item;
        }
    }
    
    public void SelectItem(string itemID)
    {
        if(itemDictionary.TryGetValue(itemID, out ItemData Selectitem))
        {
            Purchase_UI.SetActive(true);
            ItemImage.sprite = Selectitem.ItemImage;
            ItemName.text = Selectitem.ItemName;
            ItemCoin.text = $"({Selectitem.ItemPrice:N0} Point)";
            ItemExplain.text = Selectitem.ItemDescription;
        }

        else
        {
            Debug.LogError("아이템을 찾을 수 없습니다. = " + itemID);
        }
    }
}
