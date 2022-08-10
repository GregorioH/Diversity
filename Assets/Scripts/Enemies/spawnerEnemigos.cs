using UnityEngine;

public class spawnerEnemigos : MonoBehaviour
{
    public UI ui;
    public Transform[] spawnPoints;
    public GameObject[] enemySelection;
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
        Instantiate(enemySelection[i], spawnPoints[i].position, spawnPoints[i].rotation);
        
    }
}
