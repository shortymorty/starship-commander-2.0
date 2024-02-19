using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private void Awake() {
        if (instance == null){
            instance = this;
            DontDestroyOnLoad(this);
        } else if(instance != null){
            Destroy(this);
        }

        collisionclips = new AudioClip[]{collision1, collision2, collision3, collision4};
        explosionclips = new AudioClip[]{explosion2, explosion3};

    }

    [Header("--------Audio Source--------")]
    [SerializeField] AudioSource FXSounds;
    [SerializeField] AudioSource BackgroundMusic;


    [Header("--------Audio Clips--------")]

    public AudioClip background;
    public AudioClip explosion1;
    public AudioClip explosion2;
    public AudioClip explosion3;
    public AudioClip collision1;
    public AudioClip collision2;
    public AudioClip collision3;
    public AudioClip collision4;
    public AudioClip collect;
    public AudioClip shot;
    public AudioClip engine;
    public AudioClip fireworks;

    private AudioClip[] collisionclips;
    private AudioClip[] explosionclips;
    
    public void PlaySFX(AudioClip clip){
        FXSounds.PlayOneShot(clip);
    }


    public void PlayRandomSFX(){
        int clip = UnityEngine.Random.Range(0, 3);
        FXSounds.PlayOneShot(collisionclips[clip]);
    }

    public void PlayRandomExplosion(){
        int clip = UnityEngine.Random.Range(0, 1);
        FXSounds.PlayOneShot(explosionclips[clip]);

    }
    public void PlayMusic(){
        BackgroundMusic.clip = background;
        BackgroundMusic.Play();
    }

    public void StopMusic(){
        BackgroundMusic.Stop();
    }

    

}
