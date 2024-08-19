using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtPotion : MonoBehaviour {

    [Header("Public ")]
    public int healing;
 
    SpriteRenderer sp;


    private void Start() {
        sp = GetComponent<SpriteRenderer>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {

            //Si la vida del player es menor que la vida maxima se suma el heal
            if (PlayerManager.instance.healt < PlayerManager.instance.maxHealt) {

                int healSum = PlayerManager.instance.healt += healing;
                Debug.Log(healSum);
                //si la suma de la vida es mayor a la vida maxima, solo se iguala la vida a la vida maxima
                if (healSum > PlayerManager.instance.maxHealt) {

                    PlayerManager.instance.healt = PlayerManager.instance.maxHealt;
                    PlayerManager.instance.GetComponent<HealtBarScript>().getHeal(healSum);

                } else {

                    PlayerManager.instance.healt = healSum;
                    PlayerManager.instance.GetComponent<HealtBarScript>().getHeal(healSum);

                }
                
                Destroy(this.gameObject);

            }      

            //Si la vida es igual a la vida maxima, no hace nada
            if (PlayerManager.instance.healt == PlayerManager.instance.maxHealt) {

                Debug.Log("No se puede tener más vida");

            }
        }
    }

}
