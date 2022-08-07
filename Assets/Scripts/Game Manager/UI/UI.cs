using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour
{
    private PlayerStats statsJ;
    public GameObject door;


    private float tiempo;
    public Image hpBar;
    public int runesObtained = 0;
    public bool areaClear = false;

    public float enemigosSpawneados;
    public float enemigosMuertos;
    public float enemigosSpawneables;

    //[System.NonSerialized]

    [Header("HUD Texts")]
    public Text textoEnemigos;
    public Text textoTiempo;
    public Text runesObtainedText;

    // Start is called before the first frame update
    void Start()
    {
        runesObtained = 0;
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
        if (statsJ.currentHealth >= 0)
        {
            hpBar.fillAmount = (float)statsJ.currentHealth / (float)statsJ.maxHealth.GetValue();
        }

        textoEnemigos.text = "Enemies left: " + (enemigosSpawneables - enemigosMuertos).ToString();
        runesObtainedText.text = "• Find the runes: " + runesObtained.ToString() + "/3";

        if (runesObtained >= 3)
        {
           door.SetActive(false);
        }

        if (enemigosMuertos >= enemigosSpawneables && areaClear == false)
        {
            areaClear = true;
            textoEnemigos.enabled = false;
            runesObtained += 1;
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

        textoTiempo.text = "Time: " + string.Format("{0:00}:{1:00}", minutos, segundos);
    }

}
