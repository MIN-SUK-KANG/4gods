using UnityEngine;

public class Balloon : Monster
{
    [Header("Player detection")]
    [SerializeField] private float detectionRange;  //탐지범위
    [SerializeField] private float explsionRange;  //폭발범위
    [SerializeField] private float speed; //이동속도

    Transform player;

    private bool Dash; //대시여부
    private bool Explode; //폭발여부

    private RaycastHit2D isPlayerDetected;

    private float MaxRight = 3.0f;
    private float MaxLeft = -3.0f;

    private float currentPos;
    private float dir = 3.0f;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        
    }

    protected override void Update()
    {
        base.Update();
        if (player == null || Explode)
            return;

        Move();
        RayCast();
        
        
    }

    protected override void Move()
    {
        base.Move();

        currentPos += Time.deltaTime * dir;
        if (currentPos >= MaxRight)
        {
            dir *= -1.0f;
            currentPos = MaxRight;
        }

        else if (currentPos <= MaxLeft)
        {
            dir *= -1.0f;
            currentPos = MaxLeft;
        }

        transform.position = new Vector2(currentPos, transform.position.y);

    }

    protected override void Attack()
    {
        base.Attack();

       
        
    }

    public void dash()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if(!Dash && distance<detectionRange)
        {
            Dash = true;
            animator.SetBool("Dash", true);
        }

        if(Dash)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            if (distance <= explsionRange)
                explode();
        }
    }


    public void explode()
    {
        //자폭구현 예정
        Explode = true;
        this.animator.SetBool("Explode", true);
    }

    public void onExplosionAnimtionEnd()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explsionRange);
        foreach(Collider2D hit in hits)
        {
            ;
        }

        Destroy(gameObject);
    }

    public void RayCast()
    {
        isPlayerDetected = Physics2D.Raycast(transform.position, Vector2.right, detectionRange);



        if (isPlayerDetected.collider !=null)
        {
            
            if(isPlayerDetected.collider.CompareTag("Player"))
            {
                Debug.Log("Player Detected:");
                dash();
            }
        }

    }
}
