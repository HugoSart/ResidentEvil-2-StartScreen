using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {       
    
    private static readonly int Highlight = Animator.StringToHash("Highlight");    
    
    // Properties
    public string hintText = "";
    public AudioClip selectSoundEffect;
    
    // References
    private TextMeshProUGUI _hintTextMesh;
    
    // Components
    private Animator _anim;
    private TextMeshProUGUI _textMesh;
    private AudioSource _as;
    
    // Buffer
    private readonly Color32 _highlightColor = new Color32(255,255,255,255);
    private Color32 _defaultColor;

    private void Awake() {
        _hintTextMesh = GameObject.FindWithTag("HintText").GetComponent<TextMeshProUGUI>();
        _anim = GetComponent<Animator>();
        _textMesh = GetComponent<TextMeshProUGUI>();
        _as = GetComponent<AudioSource>();

        _defaultColor = _textMesh.color;
    }

    public void OnPointerEnter(PointerEventData eventData) {
        if (_anim != null) _anim.SetBool(Highlight, true);
        _hintTextMesh.text = hintText;       
        _textMesh.color = _highlightColor;
        if (selectSoundEffect != null) _as.PlayOneShot(selectSoundEffect);
    }

    public void OnPointerExit(PointerEventData eventData) {
        if (_anim != null) _anim.SetBool(Highlight, false);
        _textMesh.color = _defaultColor;
        _hintTextMesh.text = "";
    }    
    
}
