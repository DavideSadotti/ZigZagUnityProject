using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PallaController : MonoBehaviour
{
    public GameObject particle;
    [SerializeField]
    private float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
            if(Input.GetMouseButtonDown(0)) //Se l'utente clicca o tap
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                SpawnerPiattaforma.current.CominciaSpawn();

                GameManager.current.StartGame();
            }
        }

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraController>().gameOver = true; //Richiamo variabile gameOver da CameraController

            SpawnerPiattaforma.current.gameOver = true;
            GameManager.current.GameOver();
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            ChangeDirection();
        }
    }

    void ChangeDirection()
    {
        if(rb.velocity.z > 0)
        {
           rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider col)
    {        
        if(col.gameObject.tag == "PurpleDiamond")
        {
            ScoreManager.current.score += 5;
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            print("viola");
        }
        else if(col.gameObject.tag == "SilverDiamond")
        {
            ScoreManager.current.score += 20;
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            print("silver");
        }
        else if(col.gameObject.tag == "GoldDiamond")
        {
            ScoreManager.current.score += 50;
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            print("oro");
        }
        
    }
}
