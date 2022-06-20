using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishGame : MonoBehaviour
{
    public UnityAction GameFinished;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out PlayerMovement player))
        {
            player.enabled = false;
            GameFinished.Invoke();
        }
    }
}
