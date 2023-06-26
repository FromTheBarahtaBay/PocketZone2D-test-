using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletVelocity = 10f;
    [SerializeField] private FixedJoystick _joystick;
    [SerializeField] private InventoryScript _inventoryScript;
    private float _timeWaitForShooting;
    private bool _waitAfterAiming = true;

    private void FixedUpdate()
    {

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            if (_waitAfterAiming)
            {
                _timeWaitForShooting = Time.time;
                _waitAfterAiming = false;
            }

            if (Time.time - _timeWaitForShooting > 1f)
            {
                if (FindBulletInInventory())
                {
                    GameObject newBullet = Instantiate(_bullet, transform.position, transform.rotation);
                    newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletVelocity;
                    _timeWaitForShooting = Time.time;
                }
            }
        }
        else _waitAfterAiming = true;
    }

    private bool FindBulletInInventory()
    {
        for (int i = 0; i < _inventoryScript._countOfSlots; i++)
        {
            foreach (Transform child in _inventoryScript.Slots[i].transform)
            {
                if (child.gameObject.CompareTag("Item") && child.gameObject.name.Contains("Ammo"))
                {
                    Destroy(child.gameObject);
                    _inventoryScript.CurrentCountOfItemsInSlot[i]--;
                    return true;
                }
                if (_inventoryScript.CurrentCountOfItemsInSlot[i] <= 0)
                    break;
            }            
        }
        
        return false;
    }
}
