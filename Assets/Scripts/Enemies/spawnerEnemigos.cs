using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerEnemigos : MonoBehaviour
{
    public UI ui;
    public Transform[] spawnPoints;
    public GameObject enemigo;
    public GameObject enemigo2;
    public int tiempoSpawn;
    public int Intervalo; 

    void Start()
    {
        InvokeRepeating("Spawn", tiempoSpawn, Intervalo);
    }


    void Update()
    {
        if (ui.enemigosSpawneados == ui.enemigosSpawneables)
        {
            CancelInvoke("Spawn");
        }

        if (true)
        {

        }
    }


    void Spawn()
    {
        int i = Random.Range(0, 4);
        Instantiate(enemigo, spawnPoints[i].position, spawnPoints[i].rotation);
        Instantiate(enemigo2, spawnPoints[i].position, spawnPoints[i].rotation);
    }
}
