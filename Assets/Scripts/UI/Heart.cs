using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    private Image _image;
    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }

    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, 2f, Fill));
    }

    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, 2f, Destroy));
    }
    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> learpingEnd)
    {
        float elapsed = 0f;
        float nextValue;

        while (elapsed < duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
        learpingEnd?.Invoke(endValue);
    }
        public void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(this.gameObject);
    }
    public void Fill(float value)
    {
        _image.fillAmount = value;
    }  
}
