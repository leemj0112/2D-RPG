using System;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Charator : MonoBehaviour
{
    private Animator animator; //�ִϸ�����
    private Rigidbody2D rigidBody2D; //�߷�
    private AudioSource audioSource; //�Ҹ�

    public AudioClip JumpClip; //���� �Ҹ�

    public float Speed = 4f; //�ӵ�
    public float JumpPower = 6f; //���� ����

    //bool ���
    private bool isFloor;
    private bool isLadder;
    private bool isClimbing;
    private float inputVertical;
    private bool JustAttack, JustJump;

    //���� ���
    public GameObject AttackObj;
    public float AttckSpeed = 3f;
    public AudioClip AttackClip;

    //ĳ���� �ݶ��̴� ����
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
    //��ٸ�Ÿ�� �ڵ�
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
    //��ٸ�Ÿ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isLadder = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isLadder = false;
        isClimbing = false;
    }

    //���� �ڵ�
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
    //����
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
    //���� �ڵ�
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
        //�̵�
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

