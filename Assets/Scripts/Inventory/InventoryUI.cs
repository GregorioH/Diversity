using UnityEngine;

using static OVRInput;
using Button = UnityEngine.UI.Button;
using IButton = OVRInput.Button;

/* This object updates the inventory UI. */

public class InventoryUI : MonoBehaviour
{

	public Transform itemsParent;   // The parent object of all the items
	public GameObject inventoryUI;  // The entire UI

	Inventory inventory;    // Our current inventory

	InventorySlot[] slots;  // List of all the slots

	void Start()
	{
		inventory = Inventory.instance;
		inventory.onItemChangedCallback += UpdateUI;    // Subscribe to the onItemChanged callback

		// Populate our slots array
		slots = itemsParent.GetComponentsInChildren<InventorySlot>();
	}

	void Update()
	{
		// Check to see if we should open/close the inventory
		if ((Input.GetKeyDown(KeyCode.R) || GetDown(IButton.One, Controller.RTouch)) && GameObject.Find("Menu") == null)
		{
			inventoryUI.SetActive(!inventoryUI.activeSelf);
		}

		if (gameObject.activeInHierarchy == true)
        {
			GameObject playerLHand = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetChild(4).gameObject;
			gameObject.transform.position = playerLHand.transform.position;
			gameObject.transform.rotation = playerLHand.transform.rotation;
		}
	}

	// Update the inventory UI by:
	//		- Adding items
	//		- Clearing empty slots
	// This is called using a delegate on the Inventory.
	void UpdateUI()
	{
		// Loop through all the slots
		for (int i = 0; i < slots.Length; i++)
		{
			if (i < inventory.items.Count)  // If there is an item to add
			{
				slots[i].AddItem(inventory.items[i]);   // Add it
			}
			else
			{
				// Otherwise clear the slot
				slots[i].ClearSlot();
			}
		}
	}
}