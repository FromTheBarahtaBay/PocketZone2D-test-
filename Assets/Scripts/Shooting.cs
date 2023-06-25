using UnityEngine;

public class Shooting : MonoBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletVelocity = 10f;
    [SerializeField] private FixedJoystick _joystick;
    private float _timeWaitForShooting;
    private bool _waitAfterAiming = true;

    void FixedUpdate()
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
                GameObject newBullet = Instantiate(_bullet, transform.position, transform.rotation);
                newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * _bulletVelocity;
                _timeWaitForShooting = Time.time;
            }
        }
        else _waitAfterAiming = true;
    }
}
