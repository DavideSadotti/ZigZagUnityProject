using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiManager : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject gameOverPanel;
    public GameObject cliccaText;
    public TMP_Text score;
    public TMP_Text highScore1;
    public TMP_Text highScore2;
    public GameObject currentScoreObject;
    public TMP_Text currentScoreText;


    public static UiManager current; //Variabile che una volta inizializzata permette di richiamare void e variabili da questo script ad un altro

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
        if(PlayerPrefs.HasKey("highScore"))
        {
            highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
        }
        else
        {
            highScore1.text = "High Score: 0";
        }
    }

    // Update is called once per frame
    void Update()
    {
        currentScoreText.text = "Score: " + ScoreManager.current.score;
    }

    public void GameStart()
    {
        cliccaText.GetComponent<Animator>().Play("textDisappear");
        startPanel.GetComponent<Animator>().Play("startPanelDisappear");

        //Faccio apparire la label con il currentScore
        currentScoreObject.SetActive(true);
    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameOverPanel.SetActive(true);
        
        //Elimino la label con il currentScore
        currentScoreObject.SetActive(false);
    }

    public void Riparti()
    {
        SceneManager.LoadScene(0);
    }
}
