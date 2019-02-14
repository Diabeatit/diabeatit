using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wigglePointer : MonoBehaviour
{
    private bool forward;
    private float initPosX, initPosY;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("move", 1f, 0.00001f);
        initPosX = transform.position.x;
        initPosY = transform.position.y;

    }

    // Update is called once per frame
    void Update()
    {

        if (forward)
        {
            transform.position = new Vector3((float)(transform.position.x + 0.005), (float)(transform.position.y + 0.005), transform.position.z);

            if (transform.position.x > initPosX + .07)
            {
                forward = false;
            }

  
          }
        else
        {
            transform.position = new Vector3((float)(transform.position.x - 0.005), (float)(transform.position.y - 0.005), transform.position.z);

            if (transform.position.x < initPosX - .07)
            {
                forward = true;
            }
        }




    }
}
