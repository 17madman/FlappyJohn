using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMovement : MonoBehaviour
{

    
    public float scrollSpeed = 5;
    private float offset;
    private Material mat;

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Nicholas.alive == true){
            offset += (scrollSpeed*Time.deltaTime);
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
    }
}
