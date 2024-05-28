using UnityEngine;

public class Charator : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private AudioSource audioSource;

    public AudioClip JumpClip;

    public float Speed = 4f;
    public float JumpPower = 6f;

    private bool isFloor;

    private bool JustAttack, JustJump;

    public GameObject AttackObj;
    public float AttckSpeed = 3f;
    public AudioClip AttackClip;
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  
    }

    private void FixedUpdate()
    {
        Jump();
        Attack();
    }

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

    //공격
    private void Attack()
    {
        if (JustAttack)
        {
            JustAttack = false;
            animator.SetTrigger("Attack");
            audioSource.PlayOneShot(AttackClip);

            if (spriteRenderer.flipX)
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

    private void AttackCheck()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            JustAttack = true;
        }
    }

    void Update()
    {
        Move();
        JumpCheck();
        AttackCheck();
    }

    private void Move()
    {
        //이동
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }

        //좌우 이동에 따른 반전
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }

        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
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
}

