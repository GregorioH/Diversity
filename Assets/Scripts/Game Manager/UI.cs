using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerStats statsJ;

    private float tiempo;

    [Header("Textos del HUD")]
    public Text textoVidaJ;
    public Text textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textoVidaJ.text = "HP: " + statsJ.currentHealth.ToString();

        // Actualizar el tiempo restante en el HUD

        tiempo += Time.deltaTime;
        Temporizador(tiempo);
    }

    void Temporizador(float tiempoHUD)
    {
        tiempoHUD += 1;
        float minutos = Mathf.FloorToInt(tiempoHUD / 60);
        float segundos = Mathf.FloorToInt(tiempoHUD % 60);

        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }
}
