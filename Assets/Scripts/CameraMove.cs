using UnityEngine;

public class CameraMove : MonoBehaviour
{

    [SerializeField] private Transform _target;
    [SerializeField] private float _speedMovement = 3f;

    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(_target.position.x, _target.position.y, transform.position.z), _speedMovement * Time.deltaTime);
    }
}
