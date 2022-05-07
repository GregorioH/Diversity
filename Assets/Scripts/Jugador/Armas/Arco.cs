using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public GameObject Player;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //bullet.transform.position = bulletSpawnPoint.transform.position;
        //bullet.transform.forward = Player.transform.forward * speed;
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(bulletSpawnPoint.forward * speed);

    }
}
