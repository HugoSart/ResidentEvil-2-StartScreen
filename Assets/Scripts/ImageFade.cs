using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ImageFade : MonoBehaviour {
    private Image _image;
    
    public bool fadeOnAwake = false;
    public float fadeOnAwakeInitialAlpha;
    public float fadeOnAwakeFinalAlpha;
    public float fadeOnAwakeDuration;
    public float fadeOnAwakeDelay;

    private void Awake() {
        _image = GetComponent<Image>();

        if (fadeOnAwake) {
            var color = _image.color;
            color.a = fadeOnAwakeInitialAlpha;
            _image.color = color;
            Fade(fadeOnAwakeFinalAlpha, fadeOnAwakeDuration, fadeOnAwakeDelay);
        }
    }

    public void Fade(float alpha, float duration, float delay) {
        StartCoroutine(FadeAfterDelay(alpha, duration, delay));
    }

    private IEnumerator FadeAfterDelay(float alpha, float duration, float delay) {
        yield return new WaitForSeconds(delay);
        var color = _image.color;
        color.a = alpha;
        _image.DOColor(color, duration);
    }
}
