using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject _slotButton;

    [SerializeField] private InventoryScript _inventoryScript;

    

    private void Awake()
    {
        _inventoryScript = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {            
            for (int i = 0; i < _inventoryScript._countOfSlots; i++)
            {
                if (!_inventoryScript.IsFull[i])
                {
                    if (PutInTheSameSlot(i,"Ammo") || PutInTheSameSlot(i, "Makarov")) continue;

                    _inventoryScript.CurrentCountOfItemsInSlot[i]++;

                    if (_inventoryScript.CurrentCountOfItemsInSlot[i] >= _inventoryScript._maxCountOfItemsInSlot)                    
                        _inventoryScript.IsFull[i] = true;
                                                            
                    print($"Подобран {transform.gameObject.name}, в ячейке {_inventoryScript.Slots[i].name} его {_inventoryScript.CurrentCountOfItemsInSlot[i]} шт.");

                    Instantiate(_slotButton, _inventoryScript.Slots[i].transform);
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }

    private bool FindNameOfItemInSlot (GameObject slot, string str)
    {
        foreach (Transform child in slot.transform)        
            if (child.gameObject.name.Contains(str) && child.gameObject.CompareTag("Item")) return true;       

        return false;
    }

    private bool PutInTheSameSlot(int i, string str)
    {
        return FindNameOfItemInSlot(_inventoryScript.Slots[i], str) && !transform.gameObject.name.Contains(str);
    }
}
