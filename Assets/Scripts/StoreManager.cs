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

    private string SelectedItemID;

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
        if(itemDictionary.TryGetValue(itemID, out ItemData selecteditem))
        {
            Purchase_UI.SetActive(true);
            ItemImage.sprite = selecteditem.ItemImage;
            ItemName.text = selecteditem.ItemName;
            ItemCoin.text = $"({selecteditem.ItemPrice:N0} Point)";
            ItemExplain.text = selecteditem.ItemDescription;

            SelectedItemID = itemID;
        }

        else
        {
            Debug.LogError("아이템을 찾을 수 없습니다. = " + itemID);
        }
    }

    public void purchease()
    {
        ItemData selecteditem = itemDictionary[SelectedItemID];
        if (GameManager.Instance.Coin >= selecteditem.ItemPrice)
        {
            if (BackPackManager.Instance.AddItem(selecteditem))
            {
                GameManager.Instance.Coin -= selecteditem.ItemPrice;

                Debug.Log("구매 성공");
            }
            else
            {
                Debug.Log("인벤토리에 빈 공간이 없습니다.");
            }
        }
        else
        {
            Debug.Log($"잔액이 부족합니다. 잔액: {GameManager.Instance.Coin}");
        }
    }
}
