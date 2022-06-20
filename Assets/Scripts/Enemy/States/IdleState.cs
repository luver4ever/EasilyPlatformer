using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class IdleState : State
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.SetBool("isIdeling", true);
    }
    private void OnDisable()
    {
        _animator.SetBool("isIdeling", false);
    }
    
}
