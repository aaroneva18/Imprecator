using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public float healt;
    public float maxHealt;
    public int damage;
    public TMP_Text text;
    Animator ani;
    
    // Start is called before the first frame update
    void Start()
    {

        //obtencion de componentes
        ani = GetComponent<Animator>();

        //Definicion de variables 
        healt = maxHealt;
    }

    // Update is called once per frame
    void Update()
    {
        checkHeal();
    }

    //Función para recibir daño
    public void getDamage(int damageToMake) {

        healt -= damageToMake;

        if (healt <= 0) {

            Destroy(gameObject);
        }
    }

    void checkHeal() {

        text.text = healt.ToString();

    }

    

   
}
