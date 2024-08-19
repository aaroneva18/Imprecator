using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUI : MonoBehaviour
{
    [Header("Public")]
    public HealtBarScript healtBarScript;

    //[Header("SerializeField")]



    // Start is called before the first frame update
    void Start() {

        //obtencion de componentes

        //definicion de variables
        healtBarScript.healtBarSlider.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            healtBarScript.healtBarSlider.enabled = true;

        }
    }
}
