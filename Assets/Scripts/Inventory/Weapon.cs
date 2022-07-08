using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]
public class Weapon : Equipment
{
    [SerializeField]
    private GameObject WeaponItem;

    public override void Use()
    {
        base.Use();

        GameObject weapon = Instantiate(WeaponItem, GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(5).GetChild(0).position, WeaponItem.transform.rotation);

        weapon.transform.parent = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(5);
    }
}
