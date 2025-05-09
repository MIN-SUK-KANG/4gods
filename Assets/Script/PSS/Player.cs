using UnityEngine;
using UnityEngine.Video;

public class Player : MonoBehaviour
{
    [SerializeField] private int HP = 100;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    private bool isGrounded;
    private Rigidbody2D rb;
    [SerializeField] private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isGrounded = true;
    }

    private void Update()
    {
        Walk();
     
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
            Debug.Log("�����̽�");
        }
    }

    private void Walk()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // �̵� ó��
        Vector2 move = new Vector2(moveX, 0);
        move.Normalize();
        transform.Translate(move * moveSpeed * Time.deltaTime);

        // �ȱ� �ִϸ��̼� ����
        animator.SetBool("iswalk", moveX != 0);

        // ���� ���� ó��
        if (moveX > 0)
            transform.localScale = new Vector3(1, 1, 1);  // ������
        else if (moveX < 0)
            transform.localScale = new Vector3(-1, 1, 1); // ����

    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
        animator.SetBool("isjump", true);
        animator.SetBool("iswalk", false);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isjump", false);
           
        }
    }

}
