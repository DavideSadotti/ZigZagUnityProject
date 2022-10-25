using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip highScoreFx;
    private AudioSource audioSource;
    public static AudioManager current; //Variabile che una volta inizializzata permette di richiamare void e variabili da questo script ad un altro

    void Awake()
    {
        if(current == null)
        {
            current = this; //Inizializzo variabile current
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = highScoreFx;
        audioSource.volume = 0.5f;
        audioSource.Play();
    }
}
