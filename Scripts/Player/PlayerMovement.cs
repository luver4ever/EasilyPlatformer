using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class PlayerMovement : MovementPhysics
{
    private Animator _animator;
    private SpriteRenderer _sr;

    private void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        _targetVelocity = new Vector2(Input.GetAxis("Horizontal"), 0);

        Flip(_targetVelocity.x);

        _animator.SetFloat("VelocityX", Mathf.Abs(_targetVelocity.x));

        _animator.SetFloat("VelocityY", _velocity.y);

        if (Input.GetKey(KeyCode.Space) && _grounded)
        {

            _velocity.y = 5;
        }
    }

    private void Flip(float deltaX)
    {
        if (deltaX < 0)
            _sr.flipX = true;
        if (deltaX > 0)
            _sr.flipX = false;
    }    

}
