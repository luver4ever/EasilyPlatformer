using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAttackZone : MonoBehaviour
{
    public UnityAction<Player> AttackZoneEntered;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
            AttackZoneEntered?.Invoke(player);
    }
}
