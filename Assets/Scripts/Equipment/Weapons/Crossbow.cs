using UnityEngine;
using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;


public class Crossbow : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float speed = 300;

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
        instBulletRigidBody.AddForce(bulletSpawnPoint.forward * speed);
    }
}
