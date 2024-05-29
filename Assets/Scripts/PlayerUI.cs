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

    void Start()
    {
        IDtext.text = GameManager.Instance.UserID;
        GameObject playerPrefab = Resources.Load<GameObject>("Characters/" + GameManager.Instance.ChararterName);
        player = Instantiate(playerPrefab);
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
