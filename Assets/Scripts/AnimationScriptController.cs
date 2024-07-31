using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScriptController : MonoBehaviour
{
    [SerializeField] float _acceleration = 0.1f;
    [SerializeField] float _deceleration = 0.5f;
    
    Animator _animator;
    float _velocity = 0f;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var runPressed = Input.GetKey(KeyCode.LeftShift);

        Forward();

        if (_velocity < 0f)
        {
            _velocity = 0f;
        }
        
        _animator.SetFloat("Velocity", _velocity);
    }

    void Forward()
    {
        var forwardPressed = Input.GetKey(KeyCode.W);
        if (forwardPressed && _velocity < 1f)
        {
            _velocity += Time.deltaTime * _acceleration;
        }
        
        if (!forwardPressed && _velocity > 0f)
        {
            _velocity -= Time.deltaTime * _deceleration;
        }
        
        
    }
}
