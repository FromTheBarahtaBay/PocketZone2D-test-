using TMPro;
using UnityEngine;

public class ControlTextInSlot : MonoBehaviour
{
    private SlotScript _slotScript;
    private InventoryScript _inventory;
    private TextMeshProUGUI _textMeshPro;

    private void Start()
    {
        _slotScript = GetComponentInParent<SlotScript>();
        _inventory = GameObject.FindGameObjectWithTag("Inventory").GetComponent<InventoryScript>();
    }

    private void FixedUpdate()
    {
        foreach (Transform child in transform)
        { 
            if (child.gameObject.CompareTag("Text"))
            {
                if (_inventory.CurrentCountOfItemsInSlot[_slotScript.i] < 2) child.gameObject.SetActive(false);
                else child.gameObject.SetActive(true);
                _textMeshPro = child.GetComponent<TextMeshProUGUI>();
                if (_textMeshPro)
                {                    
                    _textMeshPro.text = _inventory.CurrentCountOfItemsInSlot[_slotScript.i].ToString();
                }                    
                break;
            }
        }
    }
}
