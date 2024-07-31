using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationController : MonoBehaviour
{
    [SerializeField] float _acceleration = 0.1f;
    [SerializeField] float _deceleration = 0.5f;
    
    Animator _animator;
    Vector2 _velocity;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Forward();
        Left();
        Right();

        if (_velocity.y < 0f)
        {
            _velocity.y = 0f;
        }
        
        _animator.SetFloat("Velocity Z", _velocity.y);
        _animator.SetFloat("Velocity X", _velocity.x);
    }

    void Forward()
    {
        var forwardPressed = Input.GetKey(KeyCode.W);
        if (forwardPressed && _velocity.y < 2f)
        {
            _velocity.y += Time.deltaTime * _acceleration;
        }
        
        if (!forwardPressed && _velocity.y > 0f)
        {
            _velocity.y -= Time.deltaTime * _deceleration;
        }
    }
    
    void Left()
    {
        var leftPressed = Input.GetKey(KeyCode.A);
        if (leftPressed && _velocity.x > -2f)
        {
            _velocity.x -= Time.deltaTime * _acceleration;
        }
        
        if (!leftPressed && _velocity.x < 0f)
        {
            _velocity.x += Time.deltaTime * _deceleration;
        }
    }
    
    void Right()
    {
        var rightPressed = Input.GetKey(KeyCode.D);
        if (rightPressed && _velocity.x < 2f)
        {
            _velocity.x += Time.deltaTime * _acceleration;
        }
        
        if (!rightPressed && _velocity.x > 0f)
        {
            _velocity.x -= Time.deltaTime * _deceleration;
        }
    }
}
