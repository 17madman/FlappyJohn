using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{

    public float spawnTime = 3;
    public GameObject newObject;
    private float timer = 0;

    public float heightOffset = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnTime){
            timer = timer+Time.deltaTime;
        }
        else{
            if (Nicholas.alive == true){
            spawnPipe();
            timer = 0;
            }
        }


        
        
    }

    void spawnPipe()
    {
        float lowestPoint = -1.94f;
        float highestPoint = 7.97f;
        Instantiate(newObject, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), -7f), transform.rotation);
    }
}
