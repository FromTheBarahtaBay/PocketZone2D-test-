using UnityEngine;

public class Aiming : MonoBehaviour
{

    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private float _offset = 0f;
    private float rotZ = 0f;
    private Quaternion _frize;
    private PlayerMove _playerMove;
        

    private void Awake()
    {
        _playerMove = GetComponentInParent<PlayerMove>();
        _frize = transform.localRotation;
    }

    void FixedUpdate()
    {
        if (!_playerMove._playDeathAnimationOneTime) return;

        if (_fixedJoystick.Horizontal != 0 || _fixedJoystick.Vertical != 0)
        {
            rotZ = Mathf.Atan2(_fixedJoystick.Vertical, _fixedJoystick.Horizontal) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0f, 0f, rotZ + _offset);
        }
        else transform.localRotation = Quaternion.Lerp(transform.localRotation, _frize, 3f * Time.deltaTime);
    }
}