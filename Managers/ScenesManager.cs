using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour {

    public List<Scene> scenes = new List<Scene>();

    public void Awake() {
        scenes.Add(GetCurrentScene());
    }
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void SwitchMenuInput() { }
    public void SwitchGameplayInput() { }
    public void SwitchPauseInput() { }

    public Scene GetCurrentScene ()=> SceneManager.GetActiveScene();
}
