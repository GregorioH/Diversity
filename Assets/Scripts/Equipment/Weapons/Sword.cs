using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemigo")
        {
            other.gameObject.GetComponent<Enemigo>().TakeDamage(1);
        }
    }
}
