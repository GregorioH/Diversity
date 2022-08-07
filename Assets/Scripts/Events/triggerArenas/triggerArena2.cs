using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerArena2 : MonoBehaviour
{

    public Text enemiesRemaining2;

    public GameObject doorTest3;
    public GameObject arena3Start3;
    public GameObject arena2GameManager;

    public spawnerEnemigos spawnerEnemigos3;
    

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            enemiesRemaining2.GetComponent<Text>().enabled = true;
            arena2GameManager.SetActive(true);
            doorTest3.SetActive(true);
            arena3Start3.SetActive(true);
            spawnerEnemigos3.enabled = true;
            Destroy(this.gameObject);
        }
    }
}
