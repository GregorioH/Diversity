using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultWeapon : MonoBehaviour
{
    public string weaponName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetString("Arma", weaponName);
            SceneManager.LoadScene("Juego");
        }
    }
}
