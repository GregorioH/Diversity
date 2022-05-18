using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletKill : MonoBehaviour
{
    
    
    
    void Start()
    {
        
    }


    void Update()
    {
 
    }

    private void OnTriggerEnter(Collider collision)
    {

        this.gameObject.transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;

        if (collision.gameObject.tag == "Enemigo")
        {
            this.gameObject.transform.parent = collision.gameObject.transform;
            //Destroy(collision.gameObject);
            //Destroy(this.gameObject);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        //this.gameObject.transform.localRotation = other.gameObject.transform.localRotation;
        //this.gameObject.transform.localPosition += other.gameObject.transform.localPosition;
    }
}
