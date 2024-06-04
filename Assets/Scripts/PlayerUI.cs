using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext;

    public Slider HpSlider;

    private GameObject player;

    public GameObject spawnPos;

    void Start()
    {
        IDtext.text = GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
       
    }

    void Update()
    {
        display();
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value =  GameManager.Instance.PlayerHp;
    }
}
