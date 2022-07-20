using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potionHP : MonoBehaviour
{

    public GameObject Player;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player.GetComponent<Jugador>();
           
        }
    }
}
