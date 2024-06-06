using UnityEngine;

public class Item : MonoBehaviour
{

    public AudioSource AudioSource;
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
                Debug.Log("�÷��̾� ����:" + GameManager.Instance.Coin);
                Destroy(gameObject);
            }

            if (gameObject.tag == "Boots")
            {
                Debug.Log("�÷��̾� �ӵ� 2��");
                Charator.instance.Speed += 10;
                Destroy(gameObject);

            }

            if (gameObject.tag == "HP")
            {
                GameManager.Instance.PlayerHp += 10;
                Debug.Log("�÷��̾� HP:" + GameManager.Instance.PlayerHp);
                Destroy(gameObject);
            }

            if (gameObject.tag == "axe")
            {
                Debug.Log("�÷��̾� ���� ������ 2��");
                Attack.Instance.AttackDamage += 10;
                Destroy(gameObject);
            }
        }
    }
}

