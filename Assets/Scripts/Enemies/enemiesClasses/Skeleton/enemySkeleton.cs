using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




 class enemySkeleton : Enemigo
{
    public override void Attack()
    {
        base.Attack();

        Debug.Log("Ataque esqueleto");
    }
}
