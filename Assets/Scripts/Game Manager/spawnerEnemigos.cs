using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemigos : MonoBehaviour
{
    public UI ui;
    public Transform[] spawnPoints;
    public GameObject enemigo;
    public int tiempoSpawn;
    public int Intervalo; 

    void Start()
    {
        InvokeRepeating("Spawn", tiempoSpawn, Intervalo);
    }


    void Update()
    {
        if (ui.enemigosSpawneados >= ui.enemigosSpawneables)
        {
            CancelInvoke("Spawn");
        }
    }


    void Spawn()
    {
        int i = Random.Range(0, 3);
        Instantiate(enemigo, spawnPoints[i].position, transform.rotation);
    }
}
