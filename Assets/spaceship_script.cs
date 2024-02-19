using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class spaceship_script : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 12f;
    

    public float minY, minX, maxY, maxX;
    public GameObject explosion;
    public GameObject ship_collision;
    

    private Vector3 temp = new Vector3(0f, 0f, 0f);
    private Animator anim;

    public bool isPointingLeft = false;
    public bool isPointingRight = false;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        MoveShip();

    }

    void MoveShip()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            float xDir = Input.GetAxisRaw("Horizontal");
            float yDir = Input.GetAxisRaw("Vertical");
            Vector3 playerInput = new Vector3(xDir, yDir, 0f);
            temp = transform.position + playerInput.normalized * speed * Time.deltaTime;
            if (temp.y < minY)
            {
                temp.y = minY;
            }
            else if (temp.y > maxY)
            {
                temp.y = maxY;
            }
            if (temp.x < minX)
            {
                temp.x = minX;
            }
            else if (temp.x > maxX)
            {
                temp.x = maxX;
            }


            
            transform.position = temp;
        }

        if(Input.GetAxisRaw("Horizontal") > 0){
            anim.SetTrigger("right");
            anim.SetBool("isRotatedRight", true);
            isPointingRight = true;
        }
        if(Input.GetAxisRaw("Horizontal") < 0){
            anim.SetTrigger("left");
            anim.SetBool("isRotatedLeft", true);
            isPointingLeft = true;
        }
        if(Input.GetAxisRaw("Horizontal") == 0){
             anim.SetBool("isRotatedRight", false);
             anim.SetBool("isRotatedLeft", false);
             isPointingRight = false;
             isPointingLeft = false;
         }

        
        


    }

    public void ShakeShip()
    {
        anim.SetTrigger("shake");
        Instantiate(ship_collision, transform.position, Quaternion.identity);
    }

    public void DestroyShip()
    {
        //play explosion sound
        AudioManager.instance.PlaySFX(AudioManager.instance.explosion1);
        // show an explosion and destroy the ship
        Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }
}
