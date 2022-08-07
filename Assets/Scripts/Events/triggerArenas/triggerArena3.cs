using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerArena3 : MonoBehaviour
{

    public Text enemiesRemaining;

    public GameObject doorTest;
    public GameObject arena3Start;
    public GameObject arena3Manager;

    public spawnerEnemigos spawnerEnemigos;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemiesRemaining.GetComponent<Text>().enabled = true;
            arena3Manager.SetActive(true);
            doorTest.SetActive(true);
            arena3Start.SetActive(true);
            spawnerEnemigos.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
