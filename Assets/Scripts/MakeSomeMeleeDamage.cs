using System.Security.Cryptography;
using UnityEngine;

[RequireComponent(typeof(TargetSystem), typeof (Animator))]

public class MakeSomeMeleeDamage : MonoBehaviour
{
    private Transform _targetTransform;
    [SerializeField] private Vector2 _offset;
    [SerializeField] private float _radiusForGizmo = 1.5f;
    [SerializeField] private int _minDamage = 10;
    [SerializeField] private int _maxDamage = 40;
    private Vector2 _centerPointForGizmo;
    private TargetSystem _targetSystem;
    private Animator _animator;    
    private bool _flipAttackPoint = true;
    

    private void Start()
    {
        _targetSystem = GetComponent<TargetSystem>();
        _targetTransform = _targetSystem.SetTargetFromTargetSystem;
        _animator = GetComponent<Animator>();
        _offset.x = 1.3f;
        _offset.y = -1f;
    }

    public void CreateMeleeAtacckPoint()
    {
        if (!_targetTransform) return;

        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            if (_targetTransform.position.x < transform.position.x && _flipAttackPoint)
            {
                _offset.x *= -1;
                _flipAttackPoint = false;
            } else if (_targetTransform.position.x > transform.position.x && !_flipAttackPoint)
            {
                _offset.x *= -1;
                _flipAttackPoint = true;
            }

            _centerPointForGizmo = new Vector2(transform.position.x + _offset.x, transform.position.y + _offset.y);
            DamageForEnemysInRadius(_centerPointForGizmo, _radiusForGizmo);
        }
    }

    private void DamageForEnemysInRadius(Vector2 attackPoint, float localRadius)
    {
        Collider2D[] enemys = Physics2D.OverlapCircleAll(attackPoint, localRadius);
        foreach (var enemy in enemys)
        {
            if (enemy.gameObject.layer != 8) continue;
            if (enemy.gameObject.layer != gameObject.layer)
            {
                int damage = Random.Range(_minDamage, _maxDamage);
                print($"{transform.parent.gameObject.name} hit {enemy.gameObject.name} by {damage}");
                enemy.gameObject.GetComponent<HealthBarController>().TakeDamageForHealthBar(damage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(_centerPointForGizmo, _radiusForGizmo);
    }
}
