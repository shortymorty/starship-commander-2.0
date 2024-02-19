using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Collision_script : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject explosion;

    private void Start() {
        gameManager = GameObject.Find("GameManager");
    }

    
    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "enemy"){      
            gameManager.GetComponent<GameManagerScript>().DamageOnShip();
            Instantiate(explosion, other.gameObject.transform.position, quaternion.identity);
            // play sound of collision
            AudioManager.instance.PlayRandomSFX();
        }
        if(other.gameObject.tag == "collect"){      
            gameManager.GetComponent<GameManagerScript>().CollectBonus();
            Destroy(other.gameObject);
            // play sound of collect star
            AudioManager.instance.PlaySFX(AudioManager.instance.collect);
        }
        

    }

    


}
