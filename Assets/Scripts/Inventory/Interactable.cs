using UnityEngine;
using UnityEngine.AI;

/*	
	This component is for all objects that the player can
	interact with such as enemies, items etc. It is meant
	to be used as a base class.
*/

public class Interactable : MonoBehaviour
{
	
	public float radius = 1f;
	public Transform interactionTransform;

	bool isFocus = false;   // Is this interactable currently being focused?
	Transform player;       // Reference to the player transform

	bool hasInteracted = false; // Have we already interacted with the object?

	// This method is meant to be overwritten
	public virtual void Interact()
	{
		// gameObject.transform.parent = player.gameObject.GetComponent<Jugador>().Camara.transform;
		Debug.Log("Interactuando");
	}

	public virtual void Update()
	{
		if (isFocus && !hasInteracted)    // If currently being focused
		{
			float distance = Vector3.Distance(player.position, interactionTransform.position);
			// If we haven't already interacted and the player is close enough
			if (!hasInteracted && distance <= radius)
			{
				// Interact with the object
				hasInteracted = true;
				Interact();
			}
		}
	}

	// Called when the object starts being focused
	public void OnFocused(Transform playerTransform)
	{
		isFocus = true;
		player = playerTransform;
		hasInteracted = false;
	}

	// Called when the object is no longer focused
	public void OnDefocused()
	{
		isFocus = false;
		hasInteracted = false;
		player = null;
	}

	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(interactionTransform.position, radius);
	}
	
}