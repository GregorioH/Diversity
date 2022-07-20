using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{
    private Transform Jugador;
    void Start()
    {
        Jugador = GameObject.FindObjectOfType<Jugador>().transform;
    }

    void Update()
    {
        Vector3 targetDirection = Jugador.position - transform.position;

        float singleStep = 20 * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0);

        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
