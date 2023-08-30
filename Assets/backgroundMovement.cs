using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    // Update is called once per frame
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Nicholas.alive == true){
            offset += (Time.deltaTime * scrollSpeed) / 10f;
            mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
        }
        
    }
}
