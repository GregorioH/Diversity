using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BotonesUI : MonoBehaviour
{
    public GameObject menu;
    public GameObject armas;

    public void Historia()
    {
        // Contar la historia
    }

    public void Jugar()
    {
        menu.SetActive(false);
        armas.SetActive(true);
    }

    public void Opciones()
    {
        // Abrir menu de ajustes
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void Espada()
    {
        PlayerPrefs.SetString("Arma", "Espada");
        SceneManager.LoadScene("Juego");
    }

    public void Dagas()
    {
        PlayerPrefs.SetString("Arma", "Dagas");
        SceneManager.LoadScene("Juego");
    }

    public void Arco()
    {
        PlayerPrefs.SetString("Arma", "Arco");
        SceneManager.LoadScene("Juego");
    }

    public void Baston()
    {
        PlayerPrefs.SetString("Arma", "Baston");
        SceneManager.LoadScene("Juego");
    }

    public void Cancelar()
    {
        menu.SetActive(true);
        armas.SetActive(false);
    }
}
