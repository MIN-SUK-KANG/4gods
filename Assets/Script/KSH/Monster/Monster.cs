using UnityEngine;

public class Monster : MonoBehaviour
{

    public Rigidbody2D rb2d { get; private set; } 
    public Animator animator { get; private set; } //�ִϸ�����

    protected int hp; //ü��
    protected int attackPower; //���ݷ�

    protected int direction; //����

    protected virtual void Start()
    {
        
    }

    
    protected virtual void Update()
    {
        rb2d = GetComponent<Rigidbody2D>(); //�������� ������Ʈ ��������
        animator = GetComponentInChildren<Animator>(); //���ϸ����� ������Ʈ ��������

    }

    protected virtual void Move()
    {

    }

    protected virtual void Attack()
    {

    }
}
