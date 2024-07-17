using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext; //아이디
    public Text LvText; //레벨

    public Slider HpSlider; //체력
    public Slider MpSlider; //마나
    public Slider ExpSlider; //경험치

    private GameObject player;

    void Start()
    {
        IDtext.text = GameManager.Instance.UserID;
        GameObject spwonPos = GameObject.FindGameObjectWithTag("initPos");
        player = GameManager.Instance.SpawnPlayer(spwonPos.transform);

    }

    void Update()
    {
        display();
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value = GameManager.Instance.PlayerStat.Hp;
        MpSlider.value = GameManager.Instance.PlayerStat.Mp;
        ExpSlider.value = GameManager.Instance.PlayerStat.Exp;

        LvText.text = "Lv: " + GameManager.Instance.PlayerStat.Lv;
    }
}
