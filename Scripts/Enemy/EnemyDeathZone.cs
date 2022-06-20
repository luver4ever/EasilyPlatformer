using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDeathZone : MonoBehaviour
{
    public UnityAction DeathZoneTouched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Player player))
            DeathZoneTouched?.Invoke();
    }
}
