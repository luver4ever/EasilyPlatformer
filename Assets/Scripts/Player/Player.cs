using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    
    public int Score { get; private set; }
    public int Health => _health;

    public UnityAction<int> ScoreChanged;
    public UnityAction<int> HealthChanged;
    private void Start()
    {
        HealthChanged?.Invoke(_health);
    }
    public void TakeDamage(int damage)
    {
         _health -= damage;
        if (_health <= 0)
            Time.timeScale = 0f;
    }

    public void TakeCoin(int cost)
    {
        Score += cost;
        ScoreChanged?.Invoke(Score);
    }

}
