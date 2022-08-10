using UnityEngine;

public class DemonShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawnPoint;
    public float speed;
    public void Shoot()
    {
        Vector3 playerDirection = GameObject.FindGameObjectWithTag("Player").transform.position - bulletSpawnPoint.transform.position;
        GameObject instBullet = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Rigidbody instBulletRigidBody = instBullet.transform.GetChild(0).GetComponent<Rigidbody>();
        instBulletRigidBody.AddForce(playerDirection * speed);
    }
}
