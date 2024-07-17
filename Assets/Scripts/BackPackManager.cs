using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BackPackManager : MonoBehaviour
{
    public static BackPackManager Instance;

    public GameObject BackPack_UI;
    public Text CoinText;
    public Image[] ItemImage;

    private int deflitenUsingCOunt = 0;
    private int SpeedUsingCOunt = 0;
    private int PowerUsingCOunt = 0;

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
        CoinText.text = $"Coin: {GameManager.Instance.PlayerStat.Coin}";
    }

    private void BackPackUIon()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            BackPack_UI.SetActive(!BackPack_UI.activeSelf);
        }
    }

    IEnumerator Defitem()
    {
        deflitenUsingCOunt++;
        GameManager.Instance.PlayerStat.Def *= 2;
        GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.blue;
        Debug.Log("1. PlayerDef:" + GameManager.Instance.PlayerStat.Def);
        yield return new WaitForSeconds(10f);

        deflitenUsingCOunt--;
        GameManager.Instance.PlayerStat.Def /= 2;
        if(deflitenUsingCOunt == 0)
        {
            GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. PlayerDef:" + GameManager.Instance.PlayerStat.Def);
    }

    IEnumerator Speed()
    {
        SpeedUsingCOunt++;
        GameManager.Instance.charator.Speed *= 2;
        GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log("1. Speed:" + GameManager.Instance.charator.Speed);
        yield return new WaitForSeconds(10f);

        SpeedUsingCOunt--;
        GameManager.Instance.charator.Speed /= 2;
        if (SpeedUsingCOunt == 0)
        {
            GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. Speed:" + GameManager.Instance.charator.Speed);
    }

    IEnumerator Power()
    {
        PowerUsingCOunt++;
        GameManager.Instance.CharaterAttack.AttackDamage *= 2;
        GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.green;
        Debug.Log("1. Power:" + GameManager.Instance.CharaterAttack.AttackDamage);
        yield return new WaitForSeconds(10f);

        PowerUsingCOunt--;
        GameManager.Instance.CharaterAttack.AttackDamage /= 2;
        if (PowerUsingCOunt == 0)
        {
            GameManager.Instance.charator.GetComponent<SpriteRenderer>().color = Color.white;
        }
        Debug.Log("2. Power:" + GameManager.Instance.CharaterAttack.AttackDamage);
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

    public void ItenUse()
    {
        int siblingIndex = EventSystem.current.currentSelectedGameObject.transform.parent.GetSiblingIndex();
        ItemData InventoryItem = InventoryitemDatas[siblingIndex];
        if (InventoryItem == null) { return; }

        if (InventoryItem.ItemID == "HP")
        {
            GameManager.Instance.PlayerStat.Hp += 100f;
            GameManager.Instance.PlayerStat.Hp = Mathf.Min(GameManager.Instance.PlayerStat.Hp, 100f);
            PopupMsgManager.instance.ShowPopupMassage("체력이 10 회복 되었습니다.");
        }

        else if (InventoryItem.ItemID == "MP")
        {
            GameManager.Instance.PlayerStat.Mp += 100f;
            GameManager.Instance.PlayerStat.Mp = Mathf.Min(GameManager.Instance.PlayerStat.Mp, 100f);
            PopupMsgManager.instance.ShowPopupMassage("마나가 10 회복 되었습니다.");
        }

        else if (InventoryItem.ItemID == "HP_Power")
        {
            GameManager.Instance.PlayerStat.Hp = 100f;
            PopupMsgManager.instance.ShowPopupMassage("체력이 전부 회복 되었습니다.");
        }

        else if (InventoryItem.ItemID == "MP_Power")
        {
            GameManager.Instance.PlayerStat.Mp = 100f;
            PopupMsgManager.instance.ShowPopupMassage("마나가 전부 회복 되었습니다.");
        }
        else if(InventoryItem.ItemID == "Def")
        {
            StartCoroutine(Defitem());
        }
        else if (InventoryItem.ItemID == "Power")
        {
            StartCoroutine(Power());
        }
        else if (InventoryItem.ItemID == "Speed")
        {
            StartCoroutine(Speed());
        }
        else { Debug.LogError($"존재하지 않는 아이템 ID: {InventoryItem.ItemID}");
            return;
        }
        InventoryitemDatas[siblingIndex] = null;
        EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = null;
        
    }

}
