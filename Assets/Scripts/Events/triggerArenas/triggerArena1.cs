using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerArena1 : MonoBehaviour
{

    public Text enemiesRemaining2;

    public GameObject doorTest2;
    public GameObject arena3Start2;
    public GameObject arena1GameManager;

    public spawnerEnemigos spawnerEnemigos2;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemiesRemaining2.GetComponent<Text>().enabled = true;
            arena1GameManager.SetActive(true);
            doorTest2.SetActive(true);
            arena3Start2.SetActive(true);
            spawnerEnemigos2.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
