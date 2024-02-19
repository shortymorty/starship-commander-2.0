using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed_script : MonoBehaviour
{
    public float speed;
    public int enemyHealth = 1;
    private int points;
    private readonly float minY = -6f;
    private GameObject GameManager;
    private GameManagerScript gameScript;

    private void Start() {
        points = GameObject.Find("GameManager").GetComponent<GameManagerScript>().GetPoints();
        if (points > 0){
            int speedFactor = points / 50;
            speed = Random.Range(3f + speedFactor + speed,7f + speedFactor + speed);
            //Debug.Log("speed is: " + speed);
        } else speed = 1;


        
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

    public void DecreaseHealth(){
        enemyHealth --;
    }

    public int GetEnemyHealth(){
        return enemyHealth;
    }

    public void selfDestroy(){
        Destroy(gameObject);
    }
    
}
