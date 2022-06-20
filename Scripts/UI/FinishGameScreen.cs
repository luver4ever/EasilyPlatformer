using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameScreen : MonoBehaviour
{
    [SerializeField] private GameObject _finishBar;
    [SerializeField] private FinishGame _finish;
    [SerializeField] private GameObject _infoBar;

    private void OnEnable()
    {
        _finish.GameFinished += OnGameFinish;
    }
    private void OnDisable()
    {
        _finish.GameFinished -= OnGameFinish;
    }

    private void OnGameFinish()
    {
        _infoBar.SetActive(false);
        _finishBar.SetActive(true);
        StartCoroutine(MoveScreenToTargetPoint());
    }

    private IEnumerator MoveScreenToTargetPoint()
    {
        var duration = 0f;
        var pathTime = 2f;

        while (duration < 1f)
        {
            _finishBar.transform.position = Vector3.Lerp(_finishBar.transform.position,new Vector3(0, 0, 0), duration);
            duration += Time.deltaTime / pathTime;
            yield return null;
        }
    }
}

