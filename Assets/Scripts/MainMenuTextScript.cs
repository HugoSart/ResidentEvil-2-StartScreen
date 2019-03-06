using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuTextScript : MonoBehaviour {       
    
    // Properties
    public string hintText = "";
    public AudioClip selectSoundEffect;
    
    // References
    private TextMeshProUGUI _hintTextMesh;
    private Tweener tweener;
    
    // Components
    private TextMeshProUGUI _textMesh;
    private AudioSource _as;
    
    // Buffer
    private readonly Color32 _highlightColor = new Color32(255,255,255,255);
    private Color32 _defaultColor;

    private void Awake() {
        _hintTextMesh = GameObject.FindWithTag("HintText").GetComponent<TextMeshProUGUI>();
        _textMesh = GetComponent<TextMeshProUGUI>();
        _as = GetComponent<AudioSource>();

        _defaultColor = _textMesh.color;
    }

    public void Select() {
        PlayHighlightAnim();
        _hintTextMesh.text = hintText;       
        _textMesh.color = _highlightColor;
        if (selectSoundEffect != null) _as.PlayOneShot(selectSoundEffect);
    }

    public void Unselect() {
        RewindHighlightAnim();
        _textMesh.color = _defaultColor;
        _hintTextMesh.text = "";
    }
    
    private void PlayHighlightAnim() {
        print("Moving");
        tweener = transform.DOMoveX(transform.position.x + 20f, 0.25f);
    }

    private void RewindHighlightAnim() {
        print("Rewinding: " + tweener);
        tweener?.PlayBackwards();
    }
    
}
