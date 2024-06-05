using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Image Charaterimg;
    public Text IDtext;
    public Text Cointext;

    public float TimerSecond;
    public float TimerMint;
    public Text TimeTxt;

    public Slider HpSlider;


    private GameObject player;

    public GameObject spawnPos;


    void Start()
    {
        IDtext.text = "ID: " + GameManager.Instance.UserID;
        player = GameManager.Instance.SpawnPlayer(spawnPos.transform);
       
    }

    void Update()
    {
        display();
        Cointext.text = "Coin: " + GameManager.Instance.Coin;

        TimerSecond += Time.deltaTime;
        Debug.Log((int)TimerSecond);
        TimeTxt.text = "Time: " + (int)TimerMint + "Ка " + (int) TimerSecond + "УЪ"; 
        if(TimerSecond >= 60)
        {
            TimerMint++;
            TimerSecond = 0;
        }
    }

    private void display()
    {
        Charaterimg.sprite = player.GetComponent<SpriteRenderer>().sprite;
        HpSlider.value =  GameManager.Instance.PlayerHp;
    }

}
