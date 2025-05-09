using UnityEngine;

public class Monster : MonoBehaviour
{

    public Rigidbody2D rb2d { get; private set; } 
    public Animator animator { get; private set; } //애니메이터

    protected int hp; //체력
    protected int attackPower; //공격력

    protected int direction; //방향

    protected virtual void Start()
    {
        
    }

    
    protected virtual void Update()
    {
        rb2d = GetComponent<Rigidbody2D>(); //물리엔진 컴포넌트 가져오기
        animator = GetComponentInChildren<Animator>(); //에니메이터 컴포넌트 가져오기

    }

    protected virtual void Move()
    {

    }

    protected virtual void Attack()
    {

    }
}
