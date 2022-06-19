using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] Transform colliderRoot;
    [SerializeField] float reactionMultiplier;
    [SerializeField] float damageMultiplier;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(colliderRoot.position);
        rb.MoveRotation(colliderRoot.rotation);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Enemy")) 
        {
            /*
             * esto probablemente lo tengamos que ver, algunas notas:
             * 1. Si quieren golpes individuales (que si golpeas a un enemigo haya cooldown), poner cooldown acá.
             * 2. Si quieren slashing (que golpee a muchos enemigos), poner cooldown en cada enemigo.
             
            if (enemy != null && collision.relativeVelocity.magnitude > 3f)
            {

            }
            */
        }
    }
}
