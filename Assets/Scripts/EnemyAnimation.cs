using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Animator))]

public class EnemyAnimation : MonoBehaviour
{
    private Transform _targetToMove;
    private NavMeshAgent _navMeshAgent;
    private Vector3 _flip;
    private Animator _animator;
    private float _distance;
    private TargetSystem _targetSystem;
    private HealthBarController _healthBarController;
    private DestroyObjectAfterAnimation _destroyObjectAfterAnimation;
    [SerializeField] public bool _playDeathAnimationOneTime = true;
    [SerializeField] private GameObject _itemToDrop;

    private void Start()
    {
        _destroyObjectAfterAnimation = GetComponentInParent<DestroyObjectAfterAnimation>();
        _healthBarController = GetComponentInParent<HealthBarController>();
        _targetSystem = GetComponentInParent<TargetSystem>();
        _targetToMove = _targetSystem.SetTargetFromTargetSystem;
        _navMeshAgent = GetComponentInParent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _flip = transform.eulerAngles;
    }

    private void Update()
    {
        if (!_targetToMove) return;

        if (_healthBarController.healthOfThisObject <= 0 && _playDeathAnimationOneTime)
        {
            _playDeathAnimationOneTime = false;
            _animator.Play("Death");
            transform.parent.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            Instantiate(_itemToDrop, new Vector3(Random.Range(transform.position.x - 2, transform.position.x +2), Random.Range(transform.position.y - 2, transform.position.y + 2), 0f), Quaternion.identity);
        }

        if (!_playDeathAnimationOneTime) return;

        _distance = Vector2.Distance(transform.position, _targetToMove.position);

        if (_distance < 9f)        
            if (_distance <= _navMeshAgent.stoppingDistance)
                _animator.Play("Attack");
            else _animator.Play("Walk");        
        else _animator.Play("Idle");

        if (_targetToMove.position.x < transform.position.x)
            _flip.y = 180;
        else _flip.y = 0;
        
        transform.eulerAngles = _flip;
    }

    public void DestroyObject ()
    {
        _destroyObjectAfterAnimation.DestroyObjectAfterAnim();
    }
}
