using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPiattaforma : MonoBehaviour
{
    public GameObject piattaforma;
    public GameObject diamond;
    Vector3 ultimaPos;
    Vector3 pos;
    float size;
    public bool gameOver;
    public static SpawnerPiattaforma current; //Variabile che una volta inizializzata permette di richiamare void e variabili da questo script ad un altro

    void Awake()
    {
        current = this; //Inizializzo variabile current
    }

    // Start is called before the first frame update
    void Start()
    {
        ultimaPos = piattaforma.transform.position;
        size = piattaforma.transform.localScale.x;

        for(int i = 0; i < 20; i++)
        {
            SpawnPiattaforma();
        }

        //CominciaSpawn();
    }

    public void CominciaSpawn()
    {
        InvokeRepeating("SpawnPiattaforma", 2f, 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            CancelInvoke("SpawnPiattaforma");
        }
    }

    void SpawnPiattaforma()
    {
        int rand = Random.Range(0, 6);

        if(rand < 3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        pos = ultimaPos;
        pos.x += size;
        ultimaPos = pos;
        Instantiate(piattaforma, pos, Quaternion.identity);

        SpawnDiamond();
    }

    void SpawnZ()
    {
        pos = ultimaPos;
        pos.z += size;
        ultimaPos = pos;
        Instantiate(piattaforma, pos, Quaternion.identity);

        SpawnDiamond();
    }

    void SpawnDiamond()
    {
        int rand = Random.Range(0, 10);

        if(rand == 0)
        {
            Instantiate(diamond, new Vector3(pos.x, 1.2f, pos.z), diamond.transform.rotation);
        }
    }
}
