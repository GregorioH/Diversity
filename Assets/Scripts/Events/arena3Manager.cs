using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena3Manager : MonoBehaviour
{
    public UI ui;
    public triggerArena3 triggerArena3;
    public GameObject arena3Door;
    
    void Update()
    {
        if (ui.areaClear == true)
        {
            arena3Door.SetActive(false);
            ui.enemigosMuertos = 0;
            ui.enemigosSpawneados = 0;
            ui.areaClear = false;
            Destroy(this);
        }
    }
}
