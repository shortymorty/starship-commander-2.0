using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class projectile_shoot : MonoBehaviour
{
    public GameObject bullet;

    public GameObject projectileHolder;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){

            GameObject tempBullet = Instantiate(bullet, projectileHolder.transform.position, Quaternion.Euler(transform.position));
            if(this.GetComponent<spaceship_script>().isPointingLeft){
                tempBullet.GetComponent<bullet_script>().left = true;
            }
                
            if(this.GetComponent<spaceship_script>().isPointingRight){
                tempBullet.GetComponent<bullet_script>().right = true;
            }
            // play sound when firing bullet
            AudioManager.instance.PlaySFX(AudioManager.instance.shot);
        }
    }
}
