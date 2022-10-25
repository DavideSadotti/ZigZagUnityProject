using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager current; //Variabile che una volta inizializzata permette di richiamare void e variabili da questo script ad un altro

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

    public void StartGame()
    {
        UiManager.current.GameStart();
        ScoreManager.current.StartScore();
    }

    public void GameOver()
    {
        UiManager.current.GameOver();
        ScoreManager.current.StopScore();
    }
}
