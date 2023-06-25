using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] public float healthOfThisObject = 100f;

    private void Awake()
    {
        _healthBar = GetComponentInChildren<Slider>();
    }

    private void Update()
    {
        _healthBar.value = healthOfThisObject;
    }

    public void TakeDamageForHealthBar (int damage)
    {
        healthOfThisObject -= damage;
    }
}
