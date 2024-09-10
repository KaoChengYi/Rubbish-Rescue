using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance; // Singleton
	public static List<Rubbish> items = new List<Rubbish>(); // Internal List of Inventory (Not on UI)
	public int maxInventorySize;

	//[SerializeField] Rubbish[] tempRubbish; // Temp (Spawned rubbish in inventory)

	[SerializeField] GameObject InventoryGO; // Inventory UI

	public Transform itemContent; // Content Drawer that displays inventory
	public GameObject itemGO; // The Item instantiated in Content Drawer

	private void Awake()
	{
      Instance = this;
    }

	private void Start()
	{
		items.Clear();
		RubbishManager.Instance.ClearRubbishData();
		ListItems();
    }

    private void Update()
	{
		// Press to open Inventory
		if (Input.GetKeyDown(KeyCode.Tab)) InventoryGO.SetActive(!InventoryGO.activeSelf);
    }

    /// <summary>
    /// Add Item to the Player Inventory, if less than Max Inventory Size
    /// </summary>
    /// <param name="_rubbish"></param>
    public void AddItem(Rubbish _rubbish)
    {
        if (!IsInventoryFull())
        {
            items.Add(_rubbish);

            // Use the rubbishTag from the Rubbish object
            RubbishManager.Instance.AddRubbishTag(_rubbish.rubbishTag);

            ListItems();
        }
    }



    /// <summary>
    /// List the item from internal inventory to UI Inventory
    /// </summary>
    public void ListItems()
	{
		// Remove Instantiated Items in Inventory Menu (Objects are duplicated when called from List of Inventory)
		foreach (Transform item in itemContent)
		{
			Destroy(item.gameObject);
		}

		// Instantiate items in Inventory Menu
		foreach (Rubbish item in items)
		{
			GameObject obj = Instantiate(itemGO, itemContent);
			var itemName = obj.transform.GetComponentInChildren<Text>(); // Grab the Item Name from Instantiated Item
			var itemSprite = obj.transform.GetComponentsInChildren<Image>()[1]; // Grab the Item Image from Instantiated Item

			itemName.text = item.name;
			itemSprite.sprite = item.sprite;
		}
	}




	/// Checkers


	public bool IsInventoryFull()
	{
		if (items.Count < maxInventorySize) return false;
		else return true;
	}
}