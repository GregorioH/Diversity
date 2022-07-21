using UnityEngine;
using UnityEngine.SceneManagement;

public class DefaultWeapon : MonoBehaviour
{
    public string weaponName;
    public Item otherEquipmentName;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerPrefs.SetString("Arma", weaponName);
            SceneManager.LoadScene("Juego");
            Inventory.instance.Add(otherEquipmentName);
            Inventory.instance.Add(otherEquipmentName);
            Inventory.instance.Add(otherEquipmentName);
        }
    }
}
