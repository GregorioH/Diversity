using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            GameObject.FindObjectOfType<PlayerStats>().TakeDamage(3);
            GameObject.FindObjectOfType<Jugador>().playerDamageSound();
            Destroy(gameObject);
        }
    }
}
