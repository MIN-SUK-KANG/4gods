using System.Collections;
using UnityEngine;

public class PlantMonsterFlower : Monster
{

    public float shootingInterval =2f; //�̻��� �߻� ������ �Ӵ��ð�
    public GameObject seedBullet; //�Ѿ� ������

    public Transform firePoint; //�߻� ��ġ
    public float shootTimer; //�߻� Ÿ�̸�
    


    protected override void Start()
    {
        base.Start();
       
       
    }

    protected override void Update()
    {
        base.Update();
        Attack();

    }

    protected override void Attack()
    {
        base.Attack();

        animator.SetBool("Attack", true);
        shootTimer -= Time.deltaTime;

        if (shootTimer<=0)
        {
            shootBullet();
            shootTimer = shootingInterval;
        }
        
    }

    

    public void shootBullet()
    {
        //���߽߰� �Ѿ� �߻� ���� ����



        GameObject seed = SeedPool.instance.GetSeed();
        seed.GetComponent<SeedBullet>().Fire(firePoint.position, firePoint.rotation);
        
        
        
    }
}