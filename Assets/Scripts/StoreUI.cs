using UnityEngine;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    public Image[] ItamImages;
    public Text[] ItemTexts;
    public ItemData[] itemDatas;
    void Start()
    {
        for (int i = 0; i < itemDatas.Length; i++)
        {
            ItamImages[i].sprite = itemDatas[i].ItemImage;
            ItemTexts[i].text = $"{itemDatas[i].ItemName} ({itemDatas[i].ItemPrice:N0}P)";
        }
    }


}
