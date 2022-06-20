using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    [SerializeField] private EnemyDeathZone _deathZone;
    [SerializeField] private EnemyAttackZone _attackZone;

    private Player _target;
    
    public Animator EnemyAnimator { get; private set; }
    public Player Target => _target;

    private void Awake()
    {
        EnemyAnimator = GetComponent<Animator>();
    }
    private void OnEnable()
    {
        _deathZone.DeathZoneTouched += OnEnemyDeath;
        _attackZone.AttackZoneEntered += OnEnemyAttack;
    }
    private void OnDisable()
    {
        _deathZone.DeathZoneTouched -= OnEnemyDeath;
        _attackZone.AttackZoneEntered += OnEnemyAttack;
    }

    private void OnEnemyAttack(Player player)
    {
        player.TakeDamage(_damage);
    }

    private void OnEnemyDeath()
    {
        Destroy(this.gameObject);
    }

    public void Init(Player target)
    {
        _target = target;
    }
}
