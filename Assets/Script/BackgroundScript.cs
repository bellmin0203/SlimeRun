using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public float ScrollSpeed = 0.1f; //속도
    float Target_offset;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 게임오버가 아니라면
        if(!GameManager.instance.isGameover){
            Target_offset += Time.deltaTime * ScrollSpeed;
            GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Target_offset, 0);
        }
        
        
    }
}
