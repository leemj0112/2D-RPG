using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") 
        {
            if(gameObject.tag == "Coin")
            {
                GameManager.Instance.PlayerStat.Coin += 10;
                Debug.Log("플레이어 코인:" +GameManager.Instance.PlayerStat.Coin);
                Destroy(gameObject);
            }

            else if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerStat.Hp += 10;
                Debug.Log("플레이어 HP:" + GameManager.Instance.PlayerStat.Hp);
                Destroy(gameObject);

            }
        }
    }
}
