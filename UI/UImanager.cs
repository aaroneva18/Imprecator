using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    private Canvas canvasOfScene = null;
    [SerializeField] private bool isUIactive = true;

    private void Awake() {
        canvasOfScene = GameObject.FindAnyObjectByType<Canvas>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenericLoadScene(string nameScene) { SceneManager.LoadScene(nameScene); }
    public void EnableUIofCurrentScene() {
        canvasOfScene.enabled = isUIactive;
    }
    public void DisableUIofCurrentScene() {
        canvasOfScene.enabled = !isUIactive;
    }
}
