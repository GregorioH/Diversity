using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using System.Collections.Generic;
using System.Collections;
/*
	This component is derived from CharacterStats. It adds two things:
		- Gaining modifiers when equipping items
		- Restarting the game when dying
*/

public class PlayerStats : CharacterStats
{
	public AudioSource jugador;
	public AudioClip death;
	public bool once = true;
	// Use this for initialization
    public override void Start()
	{
		base.Start();

		once = true;
		EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
	}
    
	void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
	{
		if (newItem != null)
		{
			armor.AddModifier(newItem.armorModifier);
			damage.AddModifier(newItem.damageModifier);
		}

		if (oldItem != null)
		{
			armor.RemoveModifier(oldItem.armorModifier);
			damage.RemoveModifier(oldItem.armorModifier);
		}
	}

	// Reproduce Death sound
	IEnumerator waitbeforeDie ()
    {
		playerDeathSound();
		yield return new WaitForSeconds(0.8f);
		playerDeathSoundStop();
		yield return new WaitForSeconds(2f);
		GameObject.FindObjectOfType<dontDestroy>().GetComponent<AudioSource>().Stop();
		Destroy(GameObject.FindObjectOfType<Inventory>().transform.parent.gameObject);
		SceneManager.LoadScene("Menu");
	}


	public override void Die()
    {
        if (once == true)
        {
			once = false;
			StartCoroutine(waitbeforeDie());
			
        }

    }
	
	public void playerDeathSound()
	{
		jugador.GetComponent<AudioSource>().PlayOneShot(death);
	}

	public void playerDeathSoundStop()
    {
		jugador.GetComponent<AudioSource>().Stop();
    }



}
