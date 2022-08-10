using UnityEngine;

public class bulletKill : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        //this.gameObject.transform.GetChild(3).GetComponent<BoxCollider>().enabled = false;
        //gameObject.transform.GetChild(3).GetChild(2).GetComponent<BoxCollider>().enabled = false;

        if (collision.gameObject.tag == "Enemigo")
        {
            Debug.Log("Toco");
            gameObject.transform.parent = collision.gameObject.transform;
            collision.gameObject.GetComponent<Enemigo>().TakeDamage(1);
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {

        //this.gameObject.transform.localRotation = other.gameObject.transform.localRotation;
        //this.gameObject.transform.localPosition += other.gameObject.transform.localPosition;
    }
}
