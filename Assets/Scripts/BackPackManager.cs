using UnityEngine;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;

    public GameObject BackPack_UI;
    public Text CoinText;
    public Image[] ItemImage;

    private ItemData[] InventoryitemDatas;
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        InventoryitemDatas = new ItemData[ItemImage.Length];
    }

    private void Update()
    {
        BackPackUIon();
        CoinText.text = $"Coin: {GameManager.Instance.Coin}";
    }

    private void BackPackUIon()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }
    }

    public bool AddItem(ItemData item)
    {
        for (int i = 0; i < ItemImage.Length; i++)
        {
            if (ItemImage[i].sprite == null)
            {
                ItemImage[i].sprite = item.ItemImage;
                InventoryitemDatas[i] = item;
                return true;
            }
        }
        return false;
    }
}
