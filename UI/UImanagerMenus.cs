using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanagerMenus : UImanager
{
    // Start is called before the first frame update
    void Start()
    {
        EnableUIofCurrentScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewGameButton(string NewGameScene) {
        GenericLoadScene(NewGameScene);
        //Hacer que el player haga una animacion
    }
    public void ContinueButton() {
        //TODO: Si es en HTML no tiene guardado, si es en pc usar un Json para guardar. 
    }
    public void ConfigurationButton(string ConfigurationScene) {
        GenericLoadScene(ConfigurationScene);
    }
    public void ExitButton() {
        Application.Quit();
    }

}
