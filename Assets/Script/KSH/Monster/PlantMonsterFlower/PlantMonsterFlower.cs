using System.Collections;
using UnityEngine;

public class PlantMonsterFlower : Monster
{

    public float shootingInterval =2f; //미사일 발사 사이으 ㅣ대기시간
    public GameObject seedBullet; //총알 프리팹

    public Transform firePoint; //발사 위치
    public float shootTimer; //발사 타이머
    


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
        //적발견시 총알 발사 구현 예정



        GameObject seed = SeedPool.instance.GetSeed();
        seed.GetComponent<SeedBullet>().Fire(firePoint.position, firePoint.rotation);
        
        
        
    }
}