using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;


public class Arco : MonoBehaviour
{

    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public GameObject Bow;
    public float speed = 300;
    public float rotationWishedX = 10;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)
            || GetDown(IButton.PrimaryIndexTrigger, Controller.RTouch))
        {
            Shoot();
        }

    }

   


    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);     
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(bulletSpawnPoint.right * speed);

    }

    
   


}


