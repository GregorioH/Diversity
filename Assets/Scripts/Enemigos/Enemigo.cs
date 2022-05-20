using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : CharacterStats
{
    public NavMeshAgent agente;

    public Transform jugador;

    public Stat range;

    private UI ui;

    override public void Awake()
    {
        currentHealth = maxHealth.GetValue();
        agente.speed = speed.GetValue();
        agente.stoppingDistance = range.GetValue();
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(jugador.position);

        float distrancia = Vector3.Distance(jugador.position, this.gameObject.transform.position);

        if (distrancia <= agente.stoppingDistance)
        {
            agente.speed = 0;
        }
        else
        {
            agente.speed = speed.GetValue();
        }
    }

    override public void Die()
    {
        Destroy(gameObject);

        ui = FindObjectOfType<UI>();

        ui.enemigosVivos -= 1;
    }
}
