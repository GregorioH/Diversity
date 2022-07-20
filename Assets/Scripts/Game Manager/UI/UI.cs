using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    private PlayerStats statsJ;
    public GameObject puerta;

    private float tiempo;
    public static int runesObtained = 0;

    [System.NonSerialized] public float enemigosSpawneados;
    [System.NonSerialized] public float enemigosMuertos;
    public float enemigosSpawneables;

    [Header("Textos del HUD")]
    public Text textoVidaJ;
    public Text textoEnemigos;
    public Text textoTiempo;

    // Start is called before the first frame update
    void Start()
    {
        textoEnemigos.enabled = false;
        
        statsJ = GameObject.FindObjectOfType<PlayerStats>();

        /*foreach (object enemigo in FindObjectsOfType<Enemigo>())
        {
            enemigosVivos += 1;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        textoVidaJ.text = "HP: " + statsJ.currentHealth.ToString();
        textoEnemigos.text = "Enemies left: " + (enemigosSpawneables - enemigosMuertos).ToString();

        if (runesObtained >= 3)
        {
           puerta.SetActive(false);
        }

        if (enemigosSpawneables <= 0)
        {
            textoEnemigos.enabled = false;
        }

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
