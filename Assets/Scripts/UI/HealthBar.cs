using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Heart _heartTemplate;

    private List<Heart> _hearts = new List<Heart>();
    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        CreateHeartsOnEnable();
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
        DestroyHeartOnDisable();
    }


    private void OnHealthChanged(int number)
    {
        var needValue = number - _hearts.Count;
        if(_hearts.Count < number)
        {
            for (int i = 0; i < needValue; i++)
            {
                CreateHeart();
            }
        }
        if(_hearts.Count > number)
        {
            for (int i = 0; i < needValue; i++)
            {
                DestroyHeart(_hearts[_hearts.Count - 1]);
            }
        }
    }
    private void DestroyHeartOnDisable()
    {
        var needValue = _player.Health - _hearts.Count;
        for (int i = 0; i < needValue; i++)
        {
            DestroyHeart(_hearts[_hearts.Count - 1]);
        }
    }
    private void CreateHeartsOnEnable()
    {
        var needValue = _player.Health - _hearts.Count;
        for (int i = 0; i < needValue; i++)
        {
            CreateHeart();
        }
    }
    private void CreateHeart()
    {
        Heart newHeart = Instantiate(_heartTemplate, transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();
    }
    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
