using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Consumable", menuName = "Inventory/Consumables")]
public class Consumable : Item
{
    public int Heal;
    public override void Use()
    {
        base.Use();

        GameObject.FindObjectOfType<PlayerStats>().Heal(Heal);

        Inventory.instance.Remove(this);
    }
}
