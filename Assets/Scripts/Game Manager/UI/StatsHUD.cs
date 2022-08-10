using UnityEngine;

using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;

public class StatsHUD : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) || GetDown(IButton.One, Controller.RTouch))
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(!gameObject.transform.GetChild(0).gameObject.activeSelf);
        }

        if (gameObject.activeInHierarchy == true)
        {
            GameObject playerLHand = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(4).gameObject;
            gameObject.transform.position = playerLHand.transform.position;
            gameObject.transform.rotation = playerLHand.transform.rotation;
        }
    }
}
