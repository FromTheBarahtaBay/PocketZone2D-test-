using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _minDamage = 15;
    [SerializeField] private int _maxDamage = 35;
    private bool _isActive = true;
    private HealthBarController _healthBarController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isActive) return;
        _isActive = false;

        _healthBarController = collision.gameObject.GetComponent<HealthBarController>();
        if (_healthBarController) _healthBarController.TakeDamageForHealthBar(Random.Range(_minDamage, _maxDamage));

        Destroy(transform.gameObject, 0.07f);
    }

    private void FixedUpdate()
    {
            Destroy(transform.gameObject, 7f);
    }
}
