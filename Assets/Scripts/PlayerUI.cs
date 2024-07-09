using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext;

    public Slider HpSlider;
    public Slider MpSlider;
    public Slider ExpSlider;

    private GameObject player;

    //public GameObject spawnPos;

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
        HpSlider.value = GameManager.Instance.PlayerHp;
        MpSlider.value = GameManager.Instance.PlayerMp;
        ExpSlider.value = GameManager.Instance.PlayerExp;
    }
}
