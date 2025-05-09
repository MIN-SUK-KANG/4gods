using System;
using Unity.VisualScripting;
using UnityEngine;

public class SeedBullet : MonoBehaviour
{
    public float speed = 5f;

    public object seedPool { get; internal set; }

    void Start()
    {
        
    }

    
    public void Fire(Vector3 position, Quaternion rotation)
    {
        this.transform.position = position;
        this.transform.rotation = rotation;
        this.gameObject.SetActive(true);
    }

    void Update()
    {
        this.transform.Translate(Vector3.right*speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
    }

    
}
