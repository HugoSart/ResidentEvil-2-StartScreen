using UnityEngine;

public class DontDestroy : MonoBehaviour {
    private void Awake() {
        var objs = GameObject.FindGameObjectsWithTag("Menu Background");
        if (objs.Length > 1) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }
    
}
