using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshFade : MonoBehaviour {

    private TextMeshProUGUI _textMesh;
    
    public bool fadeOnAwake = false;
    public float fadeOnAwakeAlpha;
    public float fadeOnAwakeDuration;
    public float fadeOnAwakeDelay;

    private void Awake() {
        _textMesh = GetComponent<TextMeshProUGUI>();

        if (fadeOnAwake) {
            var color = _textMesh.color;
            color.a = 0;
            _textMesh.color = color;
            Fade(fadeOnAwakeAlpha, fadeOnAwakeDuration, fadeOnAwakeDelay);
        }
    }

    public void Fade(float alpha, float duration, float delay) {
        StartCoroutine(FadeAfterDelay(alpha, duration, delay));
    }

    private IEnumerator FadeAfterDelay(float alpha, float duration, float delay) {
        yield return new WaitForSeconds(delay);
        var color = _textMesh.color;
        color.a = alpha;
        _textMesh.DOColor(color, duration);
    }

}
