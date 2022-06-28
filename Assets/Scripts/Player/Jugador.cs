using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;

public class Jugador : MonoBehaviour
{
    public CharacterController CharCont;
    public Camera Camara;
    // public Animator animator;

    private PlayerStats Stats;

    private Interactable focus;

    //public GameObject EspadaInicial;
    //public GameObject ArcoInicial;

    public float gravedad = -9.81f;
    public Vector3 direccion;

    public Transform checkPiso;
    public GameObject Manos;
    public float distanciaPiso = 0.4f;
    public LayerMask capaPiso;
    public LayerMask capaUI;
    bool tocaPiso;

    // public GameObject menuPausa;

    private void Start()
    {
        //PlayerPrefs.SetString("Arma", null);

        Stats = gameObject.GetComponent<PlayerStats>();

        if (SceneManager.GetActiveScene().name != "Menu")
        {
            if (PlayerPrefs.GetString("Arma") != "")
                AssignWweapon(PlayerPrefs.GetString("Arma"));
            else
                AssignWweapon("Arco");
        }
            // PlayerPrefs.SetString("Arma", null);

        /*
        switch (PlayerPrefs.GetString("Arma"))
        {
            case "Espada":
                GameObject Espada = Instantiate(EspadaInicial, Manos.transform.GetChild(1).position, EspadaInicial.transform.rotation);
                Espada.transform.parent = Manos.transform.GetChild(1);
                break;
            case "Arco":
                GameObject Arco = Instantiate(ArcoInicial, Manos.transform.GetChild(1).position, gameObject.transform.rotation);
                Arco.transform.parent = Manos.transform.GetChild(1);
                break;
            default:
                break;
        }*/
    }

    void Update()
    {
        // Saber si toca el piso o no

        tocaPiso = Physics.CheckSphere(checkPiso.position, distanciaPiso, capaPiso);

        if (tocaPiso && direccion.y < 0)
            direccion.y = -2f;
        

        // Movimiento

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 mover = (transform.right * x + transform.forward * z);
        CharCont.Move(Vector3.ClampMagnitude(mover, 1) * Stats.speed.GetValue() * Time.deltaTime);

        direccion.y += gravedad * Time.deltaTime;
        CharCont.Move(direccion * Time.deltaTime);

        // Guardar o sacar el arma

        if (Input.GetKeyDown(KeyCode.R) 
            || GetDown(IButton.One, Controller.RTouch))
        {
            Manos.SetActive(!Manos.activeInHierarchy);

            if (Cursor.lockState == CursorLockMode.None)
            {
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else if (Cursor.lockState == CursorLockMode.Locked)
            {
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }

        }

        /*

        // Animaciones

        if ((x != 0 || z != 0) && Stats.velocidadJ == 3 && animator.GetInteger("SUPERESTADO") != 3)
        {
            animator.SetInteger("SUPERESTADO", 1);
        }
        else if (x == 0 && z == 0 && animator.GetInteger("SUPERESTADO") != 3)
        {
            animator.SetInteger("SUPERESTADO", 0);
        }

        */


        // Limitar estadísticas

        if (Stats.currentHealth <= 0)
        {
            Stats.gameObject.GetComponent<UI>().textoVidaJ.text = "HP: 0";
        }

        // Raycast (Disparo)
        
        if (Input.GetMouseButtonDown(0)
            || GetDown(IButton.PrimaryIndexTrigger, Controller.RTouch))
        {
            RaycastHit hit;

            Debug.DrawRay(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward) * Stats.range.GetValue(), Color.green);

            /*
            if (Physics.Raycast(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward), out hit, Stats.range.GetValue()) && !Manos.activeInHierarchy)
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();

                if (interactable != null)
                { 
                    SetFocus(interactable);
                }
            }*/

            if (Physics.Raycast(Camara.gameObject.transform.position, Camara.gameObject.transform.TransformDirection(Vector3.forward), out hit, Stats.range.GetValue(), capaUI))
            {
                hit.transform.gameObject.GetComponent<Button>().onClick.Invoke();
                // Debug.Log("Funciona");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Interactable>() && focus == null)
            SetFocus(other.GetComponent<Interactable>());
    }

    // Set our focus to a new focus
    void SetFocus(Interactable newFocus)
    {
        // If our focus has changed
        if (newFocus != focus)
        {
            // Defocus the old one
            if (focus != null)
                focus.OnDefocused();

            focus = newFocus;   // Set our new focus
        }

        newFocus.OnFocused(transform);
    }

    // Remove our current focus
    void RemoveFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
    }

    // Asignar arma al empezar el juego

    void AssignWweapon(string weaponType)
    {
        if (PlayerPrefs.GetString("Arma") != null)
        {
            GameObject selectedWeapon = Resources.Load<GameObject>("Weapons/" + weaponType);
            GameObject weapon = Instantiate(selectedWeapon, Manos.transform.GetChild(0).position, selectedWeapon.transform.rotation);
            weapon.transform.parent = Manos.transform.GetChild(0);
        }
    }
}