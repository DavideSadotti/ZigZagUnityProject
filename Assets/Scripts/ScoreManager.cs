using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;
    int highScore;
    public GameObject newRecord;
    bool highScorePlayed;
    public static ScoreManager current; //Variabile che una volta inizializzata permette di richiamare void e variabili da questo script ad un altro

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
        score = 0;
        highScorePlayed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementaScore()
    {
        score += 1;

        if(PlayerPrefs.HasKey("highScore") && !highScorePlayed)
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                newRecord.SetActive(true);
                AudioManager.current.PlaySound();
                highScorePlayed = true;
            }
        }
    }

    public void StartScore()
    {
        InvokeRepeating("IncrementaScore", 0.1f, 0.5f);
    }

    public void StopScore()
    {
        CancelInvoke("IncrementaScore");
        
        //Registro l'ultimo score ottenuto
        PlayerPrefs.SetInt("score", score);

        //Registro l'high score
        if(PlayerPrefs.HasKey("highScore"))
        {
            if(score > PlayerPrefs.GetInt("highScore"))
            {
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        else
        {
            PlayerPrefs.SetInt("highScore", score);
        }
    }
}
