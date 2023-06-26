using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    [SerializeField] public int _countOfSlots = 4;

    public int _maxCountOfItemsInSlot = 3;

    private int[] _currentCountOfItemsInSlot;
    public int[] CurrentCountOfItemsInSlot
    {
        get { return _currentCountOfItemsInSlot; }
        set { _currentCountOfItemsInSlot = value; }
    }

    public bool[] _isFull;
    public bool[] IsFull
    {
        get { return _isFull; }
        set { _isFull = value; }
    }

    private GameObject[] _slots;
    public GameObject[] Slots
    {
        get { return _slots; }
        set { _slots = value; }
    }

    private GameObject _inventory;
    public GameObject _slotPrefab;
    private bool _inventoryIsActive = false;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Inventory");
        _isFull = new bool[_countOfSlots];

        _currentCountOfItemsInSlot = new int[_countOfSlots];

        _slots = new GameObject[_countOfSlots];
        for (int i = 0; i < _slots.Length; i++)
        {
            _slots[i] = Instantiate(_slotPrefab, transform);
            

                Vector3 pos = GameObject.FindGameObjectWithTag("Inventory").transform.position;
                _slots[i].transform.position = new Vector3(pos.x, pos.y + (i + i - (i * 0.25f)), pos.z);
            
            _slots[i].GetComponent<SlotScript>().i = i;
            _slots[i].gameObject.name = $"Slot ({i+1})";
        }
        _inventory.SetActive(false);
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
            for (int j = 0; j < _slots.Length; j++)
                foreach (Transform child in _slots[j].transform)
                    if (child.gameObject.name == "DeleteItem")
                    {
                        child.gameObject.SetActive(false);
                        break;
                    }
            _inventoryIsActive = false;
            _inventory.SetActive(false);
        }  
    }

}
