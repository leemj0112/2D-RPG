using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Charator : MonoBehaviour
{
    private Animator animator; //애니메이터
    private Rigidbody2D rigidBody2D; //중력
    private AudioSource audioSource; //소리

    public AudioClip JumpClip; //점프 소리

    public float Speed = 4f; //속도
    public float JumpPower = 6f; //점프 높이

    //bool 목록
    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;
    private bool JustAttack, JustJump;

    //공격 목록
    public GameObject AttackObj;
    public float AttckSpeed = 3f;
    public AudioClip AttackClip;

    //캐릭터 콜라이더 반전
    private bool faceright = true;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        Move();
        JumpCheck();
        AttackCheck();
        ClimbingCheck();
    }
    private void FixedUpdate()
    {
        Jump();
        Attack();
        Climbing();
    }
    //사다리타기 코드
    private void ClimbingCheck()
    {
        inputVertical = Input.GetAxis("Vertical");
        if (isLadder && Math.Abs(inputVertical) > 0)
        {
            isClimbing = true;
        }
    }
    private void Climbing()
    {
        if (isClimbing)
        {
            rigidBody2D.gravityScale = 0f;
            rigidBody2D.velocity = new Vector2(rigidBody2D.velocity.x, inputVertical * Speed);
        }
        else
        {
            rigidBody2D.gravityScale = 1f;
        }
    }
    //사다리타기
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = false;
    }

    //점프 코드
    private void Jump()
    {
        if (JustJump)
        {
            JustJump = false;

            rigidBody2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");
            audioSource.PlayOneShot(JumpClip);
        }

    }

    private void JumpCheck()
    {
        if (isFloor)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                JustJump = true;
            }
        }
    }
    //점프
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isFloor = true;
        }
    }
    //공격 코드
    private void Attack()
    {
        if (JustAttack)
        {
            JustAttack = false;
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);
            if (gameObject.name == "Warrior")
            {
                AttackObj.SetActive(true);
                Invoke("SetAttackObjInactive", 0.5f);
            }

            else
            {

                if (!faceright)
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 180f, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.left * AttckSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
                else
                {
                    GameObject obj = Instantiate(AttackObj, transform.position, Quaternion.Euler(0, 0, 0));
                    obj.GetComponent<Rigidbody2D>().AddForce(Vector2.right * AttckSpeed, ForceMode2D.Impulse);
                    Destroy(obj, 3f);
                }
            }
        }
    }

    private void SetAttackObjInactive()
    {
        AttackObj.SetActive(false);
    }

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            JustAttack = true;
        }
    }


    private void Move()
    {
        //이동
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (!faceright) { Flip(); }
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
            if (faceright) { Flip(); }
        }
        else
        {
            animator.SetBool("Move", false);
        }
    }

    private void Flip()
    {
        faceright = !faceright;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}

