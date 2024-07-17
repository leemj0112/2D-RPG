using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext; //���̵�
    public Text LvText; //����

    public Slider HpSlider; //ü��
    public Slider MpSlider; //����
    public Slider ExpSlider; //����ġ

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
