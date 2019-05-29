using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObjectManager : MonoBehaviour
{
    private PatformManager manager;
    public GameObject[] obstacles;
    private float spawnRate = 0.1f;
    private float nextSpawn = 0.0f;
    int offset = 0;


    void Start()
    {
        manager = GameObject.FindObjectOfType<PatformManager>();
    }

    // Update is called once per frame
    void Update()

    {

        if (Time.time > nextSpawn)
        {
            offset = manager.getOffset() - 200;

            Instantiate(obstacles[Random.Range(0, 10)], new Vector3(Random.Range(-10,10), 3, offset), Quaternion.Euler(0,90,0));

            nextSpawn = Time.time + spawnRate;

        }
      
        
        
    }
}
