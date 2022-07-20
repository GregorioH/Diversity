using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject weaponsMenu;

    public GameObject weapons;

    public void Play()
    {
        mainMenu.SetActive(false);
        weaponsMenu.SetActive(true);
        weapons.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Cancel()
    {
        mainMenu.SetActive(true);
        weaponsMenu.SetActive(false);
        weapons.SetActive(false);
    }
}
