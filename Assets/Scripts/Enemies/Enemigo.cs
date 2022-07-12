using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemigo : CharacterStats
{
    public Stat speed;
    public Stat attackSpeed;

    public NavMeshAgent agente;

    public Transform jugador;

    private UI ui;

    private float cooldownTime;

    override public void Awake()
    {
        currentSpeed = speed.GetValue();
        currentHealth = maxHealth.GetValue();
        agente.speed = speed.GetValue();
        agente.stoppingDistance = range.GetValue();
        jugador = GameObject.FindGameObjectWithTag("Player").transform;
        ui = GameObject.FindGameObjectWithTag("Game Manager").GetComponent<UI>();
        ui.enemigosSpawneados += 1;
    }

    // Update is called once per frame
    void Update()
    {
        agente.SetDestination(jugador.position);

        cooldownTime += Time.deltaTime;

        float distancia = Vector3.Distance(jugador.position, this.gameObject.transform.position);

        if (distancia > agente.stoppingDistance)
        {
            agente.speed = speed.GetValue();
            return;
        }

        agente.speed = 0;

        if (cooldownTime >= attackSpeed.GetValue())
        {
            cooldownTime = 0;

            // jugador.gameObject.GetComponent<PlayerStats>().TakeDamage(damage.GetValue());
            Attack();
        }

    }

    override public void Die()
    {
        Destroy(gameObject);

        ui = FindObjectOfType<UI>();

        ui.enemigosMuertos += 1;
    }

    public virtual void Attack()
    {
        jugador.gameObject.GetComponent<PlayerStats>().TakeDamage(damage.GetValue());
    }
}
