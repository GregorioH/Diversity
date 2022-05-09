using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    float startTime = 0f;
    float holdTime = 1f;
    bool cooldown = false;
    public Animation animationn;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float speed;
   
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldown == true)
        {
            StartCoroutine(cooldownWait());
        }
        
        if (Input.GetMouseButtonDown(0) & cooldown == false)
        {
            animationn.Play("bowRecharge");
        }

        if (Input.GetMouseButtonUp(0) & cooldown == false)
        {
            arrowShoot();
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

    void arrowShoot()
    {
        Shoot();
        cooldown = true;
    }

    IEnumerator cooldownWait()
    {
        yield return new WaitForSecondsRealtime(2);
        cooldown = false;
    }


}


