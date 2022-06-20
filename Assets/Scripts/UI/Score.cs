using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.ScoreChanged += OnScoreChange;
    }
    private void OnDisable()
    {
        _player.ScoreChanged -= OnScoreChange;
    }

    private void OnScoreChange(int score)
    {
        _text.text = score.ToString();
    }
}
