using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect_script : MonoBehaviour
{
    public float speed;
    private float minY;
    void Start()
    {
        speed = 4f;
        minY = -6f;
    }

    
    void FixedUpdate() {
        Vector3 temp = transform.position;
        float posY = temp.y;
        posY -= 1 * speed * Time.deltaTime;
        temp.y = posY;
        if(temp.y <= minY)
            selfDestroy();
        transform.position = temp;               
    }

    private void selfDestroy()
    {
        Destroy(gameObject);
    }
}
