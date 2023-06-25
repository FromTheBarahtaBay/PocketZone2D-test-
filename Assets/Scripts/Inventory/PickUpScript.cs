using UnityEngine;

public class PickUpScript : MonoBehaviour
{
    public GameObject _slotButton;

    private InventoryScript _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for(int i = 0; i < _inventory._slots.Length; i++)
            {
                if (!_inventory._isFull[i])
                {
                    _inventory._isFull[i] = true;
                    Instantiate(_slotButton, _inventory._slots[i].transform);
                    Destroy(this.gameObject);
                    break;
                }
            }
        }
    }
}
