using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerArena3 : MonoBehaviour
{
    public GameObject doorTest;
    public spawnerEnemigos spawnerEnemigos;
    public GameObject arena3Start;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorTest.SetActive(true);
            arena3Start.SetActive(true);
            spawnerEnemigos.enabled = true;
        }
    }
}
