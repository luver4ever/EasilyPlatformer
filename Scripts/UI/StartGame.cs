using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject _menu;
    [SerializeField] private GameObject _infoBar;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private Button _button;

    public UnityAction GameStarted;

    private void OnEnable()
    {
        _button.onClick.AddListener(StartThisGame);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(StartThisGame);
    }
    private void Start()
    {
        _player.enabled = false;
    }
    public void StartThisGame()
    {
        StartCoroutine(HideCanvas());
    }

    public IEnumerator HideCanvas()
    {
        float duration = 0f;

        float hideTime = 1f;
        while (duration < 1)
        {
            _menu.transform.position = Vector3.Lerp(_menu.transform.position, transform.position + new Vector3(0, 10, 0), duration);
            duration += Time.deltaTime / hideTime;
            yield return null;
        }
        
        _player.enabled = true;
        GameStarted?.Invoke();
        _infoBar.SetActive(true);
        _menu.SetActive(false);
    }
}
