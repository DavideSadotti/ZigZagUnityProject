using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Ball")
        {
            //chiamo la void che fa cadere la piattaforma
            Invoke("PiattaformaCade", 0.5f); //Chiama la void PiattaformaCade dopo 0.5 secondi
        }
    }

    void PiattaformaCade()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false;
        Destroy(transform.parent.gameObject, 2f);
    }
}
