using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public int i;
    private InventoryScript _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            if (child.gameObject.CompareTag("Item"))
            {
                SpawnItemScript script = child.GetComponent<SpawnItemScript>();
                if (script)
                {
                    script.SpawnDroppedItem();
                    Destroy(child.gameObject);
                }
                _inventory.CurrentCountOfItemsInSlot[i]--;                
                break;
            }
        }
    }

    public void ShowDeleteButton()
    {
        foreach(Transform child in transform)        
            if (child.gameObject.name == "DeleteItem")
            {
                child.gameObject.SetActive(true);
                break;
            }        
    }

    private void Update()
    {
        if (_inventory.CurrentCountOfItemsInSlot[i] < _inventory._maxCountOfItemsInSlot)
            _inventory.IsFull[i] = false;
    }
}
