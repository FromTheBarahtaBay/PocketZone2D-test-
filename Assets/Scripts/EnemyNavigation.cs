using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof (NavMeshAgent))]

public class EnemyNavigation : MonoBehaviour
{
    private Transform _targetToMove;
    [SerializeField] private float _speed = 1f;
    private NavMeshAgent _navMeshAgent;
    private float _distance;
    private TargetSystem _targetSystem;
    private EnemyAnimation _enemyAnimation;
    private PlayerMove _playerMove;

    private void Start()
    {
        _targetSystem = GetComponent<TargetSystem>();
        _targetToMove = _targetSystem.SetTargetFromTargetSystem;
        _playerMove = _targetToMove.GetComponent<PlayerMove>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _enemyAnimation = GetComponentInChildren<EnemyAnimation>();
        _navMeshAgent.updateRotation = false;
        _navMeshAgent.updateUpAxis = false;
    }

    private void LateUpdate()
    {
        if (_enemyAnimation && !_enemyAnimation._playDeathAnimationOneTime) return;
        if (!_playerMove._playDeathAnimationOneTime) return;

        _distance = Vector2.Distance(transform.position, _targetToMove.position);

        if (_distance < 9f)
        {
            _navMeshAgent.SetDestination(_targetToMove.position);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, _targetToMove.position.y), _speed * Time.deltaTime);
        }
    }
}
