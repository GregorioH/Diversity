using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    public PlayerStats statsJ;
    public GameObject totem;

    private float tiempo;

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

        if (enemigosMuertos >= enemigosSpawneables)
        {
            // SceneManager.LoadScene("Menu");
           totem.SetActive(true);
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
