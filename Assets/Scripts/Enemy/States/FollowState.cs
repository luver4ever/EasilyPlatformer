using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FollowState : State
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _animator.SetBool("isRunning", true);
    }
    private void OnDisable()
    {
        _animator.SetBool("isRunning", false);
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector3(Target.transform.position.x, transform.position.y, transform.position.z), _speed * Time.deltaTime);
    }
}
