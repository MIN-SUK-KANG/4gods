using UnityEngine;
using System.Collections.Generic;

public class SeedPool : MonoBehaviour
{
    public static SeedPool instance;

    public GameObject seedPrefab;
    public int poolSize = 10;

    private Queue<GameObject> seedPool = new Queue<GameObject>();

    private void Awake()
    {
        instance = this;

        for(int i=0;i<poolSize;i++)
        {
            GameObject seed = Instantiate(seedPrefab);
            seed.SetActive(false);
            seedPool.Enqueue(seed);
        }
    }

    public GameObject GetSeed()
    {
        if(seedPool.Count>0)
        {
            GameObject seed = seedPool.Dequeue();
            return seed;
        }
        else
        {
            GameObject seed = Instantiate(seedPrefab);
            return seed;
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
