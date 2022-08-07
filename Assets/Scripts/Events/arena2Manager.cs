using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena2Manager : MonoBehaviour
{
    public UI ui;
    public triggerArena2 triggerArena2;
    public GameObject arena2Door;
    
    void Update()
    {
        if (ui.areaClear == true)
        {
            arena2Door.SetActive(false);
            ui.enemigosMuertos = 0;
            ui.enemigosSpawneados = 0;
            ui.areaClear = false;
            Destroy(this);
        }
    }
}
