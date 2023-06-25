using UnityEngine;

public class TargetSystem : MonoBehaviour
{
    [SerializeField] private Transform _targetObjetToFind;
    
    private void Awake()
    {
        _targetObjetToFind = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public Transform SetTargetFromTargetSystem
    {
        get { return _targetObjetToFind; }
        set { _targetObjetToFind = value; }
    }
}
