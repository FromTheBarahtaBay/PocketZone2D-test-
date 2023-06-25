using UnityEngine;

public class SlotScript : MonoBehaviour
{
    public int i;
    private InventoryScript _inventory;

    private void Start()
    {
        _inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryScript>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
            _inventory._isFull[i] = false;
    }

    public void DropItem()
    {
        foreach(Transform child in transform)
        {
            child.GetComponent<SpawnItemScript>().SpawnDroppedItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}
