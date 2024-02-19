using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{

    public void SelfDestroy(){
        Destroy(gameObject);
    }
}
