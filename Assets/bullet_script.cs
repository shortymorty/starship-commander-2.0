using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class bullet_script : MonoBehaviour
{
    public float moveSpeed;
    public bool right = false;
    public bool left = false;

    public GameObject mini_explosion;
    // Start is called before the first frame update
    void Start()
    {
        Quaternion rot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
        if(left) 
            transform.Translate(Vector2.left * moveSpeed/4 * Time.deltaTime);
        if(right)
            transform.Translate(Vector2.right * moveSpeed/4 * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Boundary")
            Destroy(gameObject); 
        if(other.gameObject.tag == "enemy"){
            other.gameObject.GetComponent<Speed_script>().DecreaseHealth();
            if(other.gameObject.GetComponent<Speed_script>().GetEnemyHealth() <= 0){
                // the asteroid is dead destroy asteroid and bullet and create explosion
                Destroy(other.gameObject);
                Destroy(gameObject);
                Instantiate(mini_explosion, transform.position, quaternion.identity);
                // play sound of explosion
                AudioManager.instance.PlayRandomExplosion();
            } else {
                // the bullet hit asteroid and destroys bullet but not asteroid
                Destroy(gameObject);
            }
            
        }
    }
}
