using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask whatIsGround;

    private GameManager gameManager;


    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
        gameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        Walk();
     
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            Jump();
    }

    private void Walk()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // 이동 처리
        Vector2 move = new Vector2(moveX, 0);
        move.Normalize();
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // 걷기 애니메이션 설정
        animator.SetBool("iswalk", moveX != 0);

        // 방향 반전 처리
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);  // 오른쪽
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽

    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetBool("isjump", true);
        animator.SetBool("iswalk", false);
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Door") && collision.gameObject.GetComponent<NormalDoor>().isOpen)
        {
            gameManager.SetNextScene();
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            GameObject.FindAnyObjectByType<NormalDoor>().isOpen = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Treasure"))
        {
            collision.gameObject.GetComponent<Treasure>().acquire();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (IsGroundDetected())
        {
            isGrounded = true;
            animator.SetBool("isjump", false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (IsGroundDetected())
        {
            isGrounded = true;
            animator.SetBool("isjump", false);
        }
    }

    public bool IsGroundDetected() => Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);

    protected void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
    }
}
