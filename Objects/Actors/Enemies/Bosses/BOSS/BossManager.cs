using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;
    [Header("Public")]
    public int damage; //Daño del boss
    public int healt; //Vida del boss
    public int maxHeal; //Vida máxima del boss
    public bool getsHit; //booleano para saber si te golpean
    public bool isAlive;

    [Header("SerializeField")]
    [SerializeField] GameObject spawnFongu; //Spawn de los Fongus
    [SerializeField] GameObject spawnGobbling; //Spawn de los Gobblings
    [SerializeField] float time;
    [SerializeField] float timeToGet;

    [Header("Prefabs")]
    [SerializeField] GameObject prefabFongu;
    [SerializeField] GameObject prefabGobbling;

    //Cosas privadas
    HealtBarScript bossHealtBar; //Script de la barra de vida


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        //obtencion de componentes
        bossHealtBar = GetComponent<HealtBarScript>();

        //definicion de las variables
        healt = maxHeal;
        bossHealtBar.SetHealt(healt, maxHeal);
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (getsHit) {
            spawnEnemies();
        }
        if (!isAlive) {
            getsHit = false;    
        }
    }

    //función para obtener daño
    public void getDamage(int damageToMake) {

        healt -= damageToMake;
        bossHealtBar.getDamage(damageToMake);
        getsHit = true;
        

        if (healt <= 0) {

            isAlive = false;
            Destroy(this.gameObject);
        }

    }

    //funcion para instanciar enemigos en la zona del boss
    void spawnEnemies() {

        time += Time.deltaTime;
        if (time >= timeToGet) {
            Instantiate(prefabFongu, spawnFongu.transform.position, Quaternion.identity);
            Instantiate(prefabGobbling, spawnGobbling.transform.position, Quaternion.identity);

            time = 0;

        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") 
            && collision.GetComponent<Rigidbody2D>().velocity.y > 0) {

            PlayerManager.instance.getDamage(damage);

        }
    }
}
