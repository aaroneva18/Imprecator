using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeFlyerScript : MonoBehaviour
{

    [Header("Public")]


    [Header("SerializeField")]
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject secondWall;
    [SerializeField] float velX;
    [SerializeField] bool lastWall;

    Rigidbody2D rb2d;
    EnemyScript enemyScript;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
     
        //obtención de componentes
        rb2d = GetComponent<Rigidbody2D>();
        enemyScript = GetComponent<EnemyScript>();
        sr = GetComponent<SpriteRenderer>();

        //Definición de variables 
        lastWall = true;

        this.transform.position = firstWall.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        EyeFlyerMove();
    }

    void EyeFlyerMove() {

        Vector2 direction = (lastWall) ? (secondWall.transform.position - this.transform.position): (firstWall.transform.position - this.transform.position);
        
        direction.Normalize();

        rb2d.velocity = direction * velX;


        if (lastWall && Vector2.Distance(this.transform.position, secondWall.transform.position) < 0.1f) {

            lastWall = false;
            sr.flipX = true;

        }else if (!lastWall && Vector2.Distance(this.transform.position, firstWall.transform.position) < 0.1f) {

            lastWall = true;
            sr.flipX = false;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.instance.getDamage(enemyScript.damage);
        }
    }
}
