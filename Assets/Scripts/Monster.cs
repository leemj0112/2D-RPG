using System.Linq;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private float moveTime = 0f;
    private float tureTime = 0;

    public float MoveSpped = 3f;

    public float MonsterHP = 30f;
    public float MonsterDamage = 4f;
    public float MonsterExp = 3f;
    private bool IsDie = false;

    public GameObject[] ItemObj; //마나, 체력, 코인

    private Animator MonsterAnimator;

    void Start()
    {
        MonsterAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        MonsterMove();
    }

    private void MonsterMove()
    {
        if (IsDie) return;

        moveTime += Time.deltaTime;
        if (moveTime <= tureTime)
        {
            this.transform.Translate(MoveSpped * Time.deltaTime, 0, 0);
        }
        else
        {
            tureTime = Random.Range(1, 5);
            moveTime = 0;

            transform.Rotate(0, 180, 0);
        }
    }
    //죽음 
    private void MonsterDie()
    {
        IsDie = true;
        MonsterAnimator.SetTrigger("DIe");
        GameManager.Instance.PlayerStat.Exp += MonsterExp;

        int ItemRandom = Random.Range(0, ItemObj.Length * 2);
        if (ItemRandom < ItemObj.Length)
        {
            Instantiate(ItemObj[ItemRandom], new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
            Debug.Log("아이템 생성됌");
        }

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f); //이동 애니메이션 재생 시간 보장
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDie) return;
        if (collision.gameObject.tag == "Player")
        {
            MonsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerStat.Hp -= MonsterDamage;
        }

        if(collision.gameObject.tag == "Attack")
        {
            MonsterAnimator.SetTrigger("Damage");
            MonsterHP -= collision.gameObject.GetComponent<Attack>().AttackDamage;

            if(MonsterHP<= 0)
            {
                MonsterDie();
            }
        }
    }
}
