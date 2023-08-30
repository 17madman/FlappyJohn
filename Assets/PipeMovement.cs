using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PipeMovement : MonoBehaviour
{

    public float moveSpeed = 5;
    public float despawnDist = 0;
    public bool isAlive = Nicholas.alive;
    // Start is called before the first frame update
    void Start()
    {
 
    }



    // Update is called once per frame
    void Update()
    {   
        if (Nicholas.alive == true){
            transform.position += (Vector3.left * moveSpeed) * Time.deltaTime;
        }
        if (transform.position.x < despawnDist){
            Destroy(gameObject);
        }
    }
}
