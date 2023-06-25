using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public bool[] _isFull;
    public GameObject[] _slots;
    private GameObject _inventory;
    private bool _inventoryIsActive = false;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    public void OpenInventory()
    {
        if (!_inventoryIsActive)
        {
            _inventoryIsActive = true;
            _inventory.SetActive(true);
        }
        else
        {
            _inventoryIsActive = false;
            _inventory.SetActive(false);
        }
            

    }
}
