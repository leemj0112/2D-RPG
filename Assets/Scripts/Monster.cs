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
        GameManager.Instance.PlayerExp += MonsterExp;

        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject, 2f); //이동 애니메이션 재생 시간 보장
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsDie) return;
        if (collision.gameObject.tag == "Player")
        {
            MonsterAnimator.SetTrigger("Attack");
            GameManager.Instance.PlayerHp -= MonsterDamage;
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
