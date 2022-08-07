using UnityEngine;

using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;

public class StatsHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.R) || GetDown(IButton.One, Controller.RTouch)) && GameObject.Find("Menu") == null)
        {
            gameObject.SetActive(gameObject.activeSelf);
        }

        if (gameObject.activeInHierarchy == true)
        {
            GameObject playerLHand = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(4).gameObject;
            gameObject.transform.position = playerLHand.transform.position;
            gameObject.transform.rotation = playerLHand.transform.rotation;
        }
    }
}
