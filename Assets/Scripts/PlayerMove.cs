using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(HealthBarController))]

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed = 300f;
    [SerializeField] private FixedJoystick _joystick;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    float _flip = 1f;
    private List<SpriteRenderer> _spriteRenderers;
    private HealthBarController _healthBarController;
    public bool _playDeathAnimationOneTime = true;

    private void Awake()
    {
        _healthBarController = GetComponent<HealthBarController>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderers = new List<SpriteRenderer>();
        foreach (var e in GetComponentsInChildren<SpriteRenderer>())        
            if (e.CompareTag("ToFlip")) _spriteRenderers.Add(e.GetComponent<SpriteRenderer>());        
    }

    private void FixedUpdate()
    {
        if (_healthBarController.healthOfThisObject <= 0 && _playDeathAnimationOneTime)
        {
            _playDeathAnimationOneTime = false;
            _animator.Play("Death");
        }

        if (!_playDeathAnimationOneTime) return;

        _rigidbody2D.velocity = new Vector3(_joystick.Horizontal * _speed * Time.deltaTime, _joystick.Vertical * _speed * Time.deltaTime, 0f);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            _animator.Play("Walk");
            if (_joystick.Horizontal < 0 && _flip > 0)
                FlippingSprites(true);
             else if (_joystick.Horizontal > 0 && _flip < 0)
                FlippingSprites(false);
            
        }
        else _animator.Play("Idle");
    }

    private void FlippingSprites (bool b)
    {
        _flip *= -1;
        foreach (var e in _spriteRenderers)
            e.flipX = b;
    }
}
