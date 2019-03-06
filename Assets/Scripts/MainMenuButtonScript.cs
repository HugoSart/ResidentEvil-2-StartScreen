using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuButtonScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

    private MainMenuTextScript textScript;

    private void Awake() {
        textScript = GetComponentInChildren<MainMenuTextScript>();
    }

    public void OnPointerEnter(PointerEventData eventData) {
        textScript.Select();
    }

    public void OnPointerExit(PointerEventData eventData) {
        textScript.Unselect();
    }
}
