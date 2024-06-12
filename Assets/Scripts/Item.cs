using UnityEngine;

public class Item : MonoBehaviour
{

    private AudioSource AudioSource;
    public AudioClip ItemEat;

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayOneShot(ItemEat);

            if (gameObject.tag == "Coin")
            {
                GameManager.Instance.Coin += 10;
                Debug.Log("플레이어 코인:" + GameManager.Instance.Coin);
                Destroy(gameObject, 0.3f);
            }

            if (gameObject.tag == "Boots")
            {
                Debug.Log("플레이어 속도 증가");
                collision.gameObject.GetComponent<Charator>().Speed += 4;
                Destroy(gameObject, 0.3f);

            }

            if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHp += 10;
                Debug.Log("플레이어 HP:" + GameManager.Instance.PlayerHp);
                Destroy(gameObject, 0.3f);
            }

            if (gameObject.tag == "axe")
            {
                Debug.Log("플레이어 어택 데미지 증가");
                collision.gameObject.GetComponent<Charator>().AttackObj.GetComponent<Attack>().AttackDamage += 4;
                Destroy(gameObject, 0.3f);
            }
        }
    }
}

