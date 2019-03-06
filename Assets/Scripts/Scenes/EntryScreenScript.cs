using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryScreenScript : MonoBehaviour {

    private ImageFade _imageFade;
    private AudioSource _sceneEndAudio;
    private GameObject[] _infos;

    private void Awake() {
        _imageFade = GameObject.FindWithTag("FadeImage").GetComponent<ImageFade>();
        _sceneEndAudio = GameObject.FindWithTag("SceneEndAudio").GetComponent<AudioSource>();
        _infos = GameObject.FindGameObjectsWithTag("Info");
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            LoadMainMenu();
    }

    public void LoadMainMenu() {
        _imageFade.Fade(1, 3, 0);
        _sceneEndAudio.Play();
        foreach (var info in _infos)
            Destroy(info);
        StartCoroutine(LoadMainMenuAfterDelay(5));
    }

    private static IEnumerator LoadMainMenuAfterDelay(float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
    }
    
}
