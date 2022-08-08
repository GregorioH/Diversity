using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class totemWinCondition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindObjectOfType<dontDestroy>().GetComponent<AudioSource>().Stop();
            SceneManager.LoadScene("Menu");
        }
    }
}
