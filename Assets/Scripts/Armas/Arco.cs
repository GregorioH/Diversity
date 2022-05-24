using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arco : MonoBehaviour
{
    float cooldownTimer = 1f;
    public float holdSTR = 0;
    bool cooldown = false;
    bool hold = false;
    public Animation animationn;
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float speed;
    int strV = 1;
    int mulStrV = 350;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) & cooldown == false & hold == true)
        {
            strenghtBow();
        }

        if (Input.GetMouseButton(0) & cooldown == false & hold == false)
        {
            animationn.Play("bowNewAnimIdle");
            hold = true;
        }

        if (Input.GetMouseButtonUp(0) & cooldown == false)
        {
            arrowShoot();
        }

        if (speed <= 100)
        {
            speed = 100;
        }
        speed = holdSTR;

        if (cooldown == true)
        {
            StartCoroutine(cooldownWait());

        }

    }

    void FixedUpdate()
    {

    }

    void arrowShoot()
    {
        cooldown = true;
        Shoot();
        animationn.Play("bowResetNew");
        hold = false;
    }

    void Shoot()
    {
        GameObject instBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        //bullet.transform.position = bulletSpawnPoint.transform.position;
        //bullet.transform.forward = Player.transform.forward * speed;
        Rigidbody instBulletRigidBody = instBullet.GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(bulletSpawnPoint.forward * speed);
        holdSTR = 0;
        speed = 0;

    }

    void strenghtBow()
    {
        if (holdSTR > 1000)
        {
            holdSTR = 1000;
        }

        else if (holdSTR < 100)
        {
            holdSTR = 100;
        }
        holdSTR += strV * mulStrV * Time.deltaTime;
        
    }

    IEnumerator cooldownWait()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0)
        {
            cooldown = false;
            cooldownTimer = 1f;
        }
        yield return new WaitForSecondsRealtime(1);
    }


}


