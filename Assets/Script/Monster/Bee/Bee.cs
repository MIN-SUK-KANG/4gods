using UnityEngine;



public class Bee : Monster
{
   

    const float MaxSpeed = 1.0f; //이동속도 최대값
    protected float speed; //이동속도
    
    private float MaxRight=3.0f;
    private float MaxLeft=-3.0f;
    
    private float currentPos;
    private float dir=3.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        currentPos = transform.position.x;
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        Move();




    }

    protected override void Move() //좌우이동반복
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

    

    
}
