using System.Collections;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class CharacterController : MonoBehaviour
{
    public int speed;
    public int jumpSpeed;
    public int damage = 1;

    Animator animator;
    Rigidbody2D rb;


    bool canJump = true;
    bool faceRight = true;
    bool canAttack = true;

    Vector2 forward;
    public Vector3 offset;

    RaycastHit2D hit;


    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        float moveInput = CrossPlatformInputManager.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump_();
        }

        if (Input.GetKeyDown(KeyCode.F) && canAttack)
        {
            Attack();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Platform")
        {
            canJump = true;
        }
    }


    private void Jump_()
    {
        if (canJump)
        {
            rb.AddForce(Vector2.up * jumpSpeed);
            canJump = false;
        }
    }

    private void Flip()
    {
        faceRight = !faceRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    private void Attack()
    {
        canAttack = false;

        if (!faceRight)
        {
            forward = transform.TransformDirection(Vector2.right * -2);
        }
        else
        {
            forward = transform.TransformDirection(Vector2.right * 2);
        }

         hit = Physics2D.Raycast(transform.position + offset, forward, 1.0f);

        if (hit)
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.GetComponent<SimpleEnemeyBehaviour>().TakeDamage(damage);
            }
            else
            {
                Debug.Log("asfdad");
            }
        }

        animator.SetTrigger("attack");

        StartCoroutine(AttackDelay());

    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(0.42f);
        canAttack = true;
    }

    public void AttacktButton()
    {
        if (canAttack)
        {
            Attack();
        }
    }

    public void Right_Left() 
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput > 0 || moveInput < 0)
        {
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (faceRight == true && moveInput < 0)
        {
            Flip();
        }
        else if (faceRight == false && moveInput > 0)
        {
            Flip();
        }
    }

    public void JumpButton()
    {
        Jump_();
    }
}
