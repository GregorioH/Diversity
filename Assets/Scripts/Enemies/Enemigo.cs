using UnityEngine;
using UnityEngine.AI;

public class Enemigo : CharacterStats
{
    public Stat speed;
    public Stat attackSpeed;


    public NavMeshAgent agente;

    public Animator animator;

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

        float distancia = Vector3.Distance(new Vector3(jugador.position.x, 0, jugador.position.z), new Vector3(gameObject.transform.position.x, 0, gameObject.transform.position.z));

        if (distancia > agente.stoppingDistance)
        {
            agente.speed = speed.GetValue();

            animator.SetInteger("SUPERESTADO", 0);

            return;
        }

        agente.speed = 0;

        if (cooldownTime >= attackSpeed.GetValue())
        {
            cooldownTime = 0;

            // jugador.gameObject.GetComponent<PlayerStats>().TakeDamage(damage.GetValue());
            Attack();
            animator.SetInteger("SUPERESTADO", 1);
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
        /*
        if (GameObject.FindObjectOfType<PlayerStats>().currentHealth > 0)
        {
            GameObject.FindObjectOfType<PlayerStats>().TakeDamage(damage.GetValue());
            GameObject.FindObjectOfType<Jugador>().playerDamageSound();
        }
        */
    }
}
