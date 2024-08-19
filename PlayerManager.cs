using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [Header("Public")]
    public static PlayerManager instance; //Singleton del player
    public int damage; //daño que hace el player
    public int healt; //vida del player
    public int maxHealt; //vida maxima del player
    public bool isAlive; //booleano si esta activo o deasctivo el player
    public bool isBossZone; //boolena que se activa si estas en la zona del boss final
    public TMP_Text textMeshPro; //Vida del jugador mostrado en pantalla
    public bool isAttacking;
    

    [Header("SerializeField")]
    //[SerializeField] GameObject target; //enemigo del player
    [SerializeField] Transform feetPosition;
    [SerializeField] float feetRadious;
    [SerializeField] Slider bossSlider;

    //Cosas privadas
    Animator ani;
    HealtBarScript healtBar;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //Obtenemos los componentes necesarios
        ani = GetComponent<Animator>();
        healtBar = GetComponent<HealtBarScript>();

        //Definición de variables
        isAlive = true;
        healt = maxHealt;
        healtBar.SetHealt(healt, maxHealt);
        bossSlider.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Función para activar las animaciones del jugador
    public void playerAttack() {

        if (Input.GetKeyDown(KeyCode.K)) {
            ani.SetTrigger("isAttacking");
            ani.SetBool("isRunning", false);
            ani.SetBool("isJummping", false); 
        }

    }

    //Función para obtener daño 
    public void getDamage(int damageToMake) {
        healt -= damageToMake;
        healtBar.getDamage(damageToMake);

        if (healt <= 0) {
            this.GetComponent<Renderer>().enabled = false;

        }
    }

    //Actualiza el string de la vida en UI
    void checkHeal() {

        textMeshPro.text = healt.ToString();


        //Si te mueres por DeadZone se bajan los parametros a 0
        if (!isAlive) {
            healtBar.getDamage(maxHealt);
            textMeshPro.text = 0.ToString();
        }

    }

    //función para activar la barra de vida del jefe
    void checkBossSlider() {

        if (isBossZone) {
            bossSlider.gameObject.SetActive(true);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {

        //Checamos la colisión en trigger y el input para hacer daño
        if (collision.CompareTag("Enemy") && Input.GetKeyDown(KeyCode.K)) {

            collision.GetComponent<EnemyScript>().getDamage(damage);

        }

        if (collision.CompareTag("Boss")) {
            collision.GetComponent<BossManager>().getDamage(damage);
        }

    }

    //si colisionamos con la zona del enemigo desactivamos el box collider y activamos la barra del jefe
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("BossZone")) {

            isBossZone = true;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

}
