using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    [Header("Public")]


    [Header("SerializeField")]
    [SerializeField] GameObject firstWall;
    [SerializeField] GameObject secondWall;
    [SerializeField] bool lastWall;
    [SerializeField] float velX;

    //Cosas privadas
    Rigidbody2D rb2d;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        
        //Obtencion de componentes
        rb2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        //Declaracion de varibles
        lastWall = true;

        this.transform.position = firstWall.transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        BossMove();
    }

    //Función para mover al boss 
    void BossMove() {

        Vector2 direction = (lastWall) ? (secondWall.transform.position - this.transform.position) : (firstWall.transform.position - this.transform.position);

        direction.Normalize();

        rb2d.velocity = direction * velX;


        if (lastWall && Vector2.Distance(this.transform.position, secondWall.transform.position) < 0.1f) {

            lastWall = false;
            sr.flipX = true;

        } else if (!lastWall && Vector2.Distance(this.transform.position, firstWall.transform.position) < 0.1f) {

            lastWall = true;
            sr.flipX = false;
        }

    }
}
