using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arena1Manager : MonoBehaviour
{
    public UI ui;
    public triggerArena1 triggerArena1;
    public GameObject arena1Door;
    
    void Update()
    {
        if (ui.areaClear == true)
        {
            arena1Door.SetActive(false);
            ui.enemigosMuertos = 0;
            ui.enemigosSpawneados = 0;
            ui.areaClear = false;
            Destroy(this);
        }
    }
}
