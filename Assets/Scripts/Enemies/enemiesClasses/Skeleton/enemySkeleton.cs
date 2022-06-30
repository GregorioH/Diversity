using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;




 class enemySkeleton : CharacterStats
{

    public Stat skeletonMaxHealth;
    public Stat skeletonMaxSpeed;
    public Stat skeletonMaxRange;
    
    int skeletonHealth { get; set; }
    int skeletonSpeed { get; set; }
    int skeletonRange { get; set; }


    override public void Awake()
    {
        skeletonHealth = skeletonMaxHealth.GetValue();
        skeletonSpeed = skeletonMaxSpeed.GetValue();
        skeletonRange = skeletonMaxRange.GetValue();

    }

}
