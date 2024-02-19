using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;



public class GameManagerScript : MonoBehaviour
{
    public GameObject asteroid1;
    public GameObject asteroid2;
    public GameObject asteroid3;
    public GameObject rocks1;
    public GameObject collectStar;
    
    private bool stillAlive = true;
    public Text pointText;
    
    // healthbar variables    
    public GameObject healthBar;
    Image healthImage;
    
    

    // player variables
    private GameObject player;
    public GameObject prefabPlayer;
    public int points;
    public int health;
    private int a;

    // UI - elements 
    public Button playButton;
    public Text gameoverText;

    // animation for ship
    private Animator anim;
    

    void Start()
    {
        healthImage = healthBar.GetComponent<Image>();
        points = 0;
        InvokeRepeating("SpawnAsteroid1", 0.1f, Random.Range(0.3f, 2f));
        InvokeRepeating("SpawnAsteroid2", 3f, Random.Range(0.3f, 2f));
        InvokeRepeating("SpawnAsteroid3", 2f, Random.Range(0.3f, 2f));
        InvokeRepeating("SpawnRocks1", 3f, Random.Range(3f, 6f));
        // create collect star
        InvokeRepeating("SpawnCollect", Random.Range(5f, 8f), Random.Range(10f, 12f));
        player = Instantiate(prefabPlayer, new Vector3(0f,-2f,0f), Quaternion.identity);
        AudioManager.instance.PlayMusic();
    }

    public int GetPoints(){
        return points;
    }

    public void DamageOnShip(){
        
        health -= 10;
        // warn the player if health is beneath 10
        if (health < 10){
            healthImage.color = Color.red;
        }
            // if ships health is zero then game over
        if (health <= 0){
            GameOver();
        } else {
            // else make shake the ship
            player.GetComponent<spaceship_script>().ShakeShip();

        }
        // sound

            
        // size the healthbar after damage
        healthImage.rectTransform.sizeDelta = new Vector2(health*180/100, 60);
    }

    public void CollectBonus(){
        if(health == 100)
            points += 100;
        else{
            health += 15;
            if(health > 100)
                health = 100;
        }
        healthImage.rectTransform.sizeDelta = new Vector2(health*180/100, 60);
    }

    private void GameOver()
    {
        stillAlive = false;
        player.GetComponent<spaceship_script>().DestroyShip();
        //Debug.Log("game over");
        gameoverText.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true); 
        AudioManager.instance.StopMusic();       
    }

    public void StartGameAgain()
    {
        // reform all the player points
        points = 0;
        health = 100;
        // size the healthbar
        healthImage.rectTransform.sizeDelta = new Vector2(health*180/100, 60);
        healthImage.color = Color.white;
        stillAlive = true;
        // hide the "game over" - text and button
        gameoverText.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        // make a new player and assign him to the player
        player = Instantiate(prefabPlayer, new Vector3(0f,-2f,0f), Quaternion.identity);
        AudioManager.instance.PlayMusic();
    }

    private void FixedUpdate() {
        a++;
        if(a>=8 && stillAlive){
            points = 1 + points;
            a = 0;
        }
        pointText.text = "score: " + points;
    }
    void SpawnAsteroid1(){     
        // asteroid1   
        float x = Random.Range(-9f,9f);
        Instantiate(asteroid1, new Vector3(x, 6f, 0), Quaternion.identity);                
    }

    void SpawnAsteroid2(){
        // asteroid2
        float x = Random.Range(-9f,9f);
        Instantiate(asteroid2, new Vector3(x, 6f, 0), Quaternion.identity);
    }

    void SpawnAsteroid3(){
        // asteroid2
        float x = Random.Range(-9f,9f);
        Instantiate(asteroid3, new Vector3(x, 6f, 0), Quaternion.identity);
    }
    void SpawnRocks1(){
        // asteroid2
        float x = Random.Range(-9f,9f);
        Instantiate(rocks1, new Vector3(x, 6f, 0), Quaternion.identity);
    }

    void SpawnCollect(){
        float x = Random.Range(-9f,9f);
        Instantiate(collectStar, new Vector3(x, 6f, 0), Quaternion.identity);
    }
}
