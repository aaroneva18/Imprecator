using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class GobblingScript : MonoBehaviour {

    [Header("Public")]


    [Header("SerializeField")]
    [SerializeField] GobblingState gobblingState;
    [SerializeField] float offset;
    [SerializeField] float maxOffset;
    [SerializeField] bool playerPercibido;


    Rigidbody2D rb2d;
    Animator ani;
    GameObject target;
    EnemyScript enemyScript;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start() {

        //obtenemos los componentes 
        rb2d = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        enemyScript = GetComponent<EnemyScript>();
        sr = GetComponent<SpriteRenderer>();

        playerPercibido = false;
    }

    // Update is called once per frame
    void Update() {


        if (PlayerManager.instance.transform.position.x < this.transform.position.x) {

            sr.flipX = true;
        }

        else if (PlayerManager.instance.transform.position.x > this.transform.position.x) {

            sr.flipX = false;
        }

        gobblingPerception();
        gobblingManager();

    }

    void gobblingPerception() {

        //si la velocidad es 0 se pone el estado de iddle
        if (rb2d.velocity == Vector2.zero) {
            gobblingState = GobblingState.Iddle;
            playerPercibido = false;
        }
        //si la distancia entre ellos es menor que maxoffset, se pone el estado de seek
        if (Vector2.Distance(PlayerManager.instance.transform.position, this.transform.position) < maxOffset) {

                gobblingState = GobblingState.Seek;
                playerPercibido = true;

        }

            //si la distancia entre ellos es menor que el offset, se pone el estado attack
        if (Vector2.Distance(PlayerManager.instance.transform.position, this.transform.position) < offset) {

                gobblingState = GobblingState.Attack;
                playerPercibido = true;
        }
    }

    void gobblingManager() {

        switch (gobblingState) {
            case GobblingState.Iddle:
                iddle();
                break;

            case GobblingState.Attack:
                attack();
                break;

            case GobblingState.Seek:
                seek();
                break;
        }

    } 

    void iddle() {
        ani.SetBool("isIddle", true);
        ani.SetBool("isRunning", false);
        ani.SetBool("isAttacking", false);
    }

    void attack() {

        ani.SetBool("isAttacking", true);
        ani.SetBool("isIddle", false);
        ani.SetBool("isRunning", false);


    }

    void seek() {

        //calculamos el vector para seguirlo
        Vector2 SeekVector = this.transform.position - PlayerManager.instance.transform.position;
        rb2d.velocity -= SeekVector * Time.deltaTime;

        ani.SetBool("isRunning", true);
        ani.SetBool("isAttacking", false);
        ani.SetBool("isIddle", false);

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerManager>().getDamage(enemyScript.damage);
        }
    }



    enum GobblingState {
        Iddle, 
        Seek,
        Attack
    }
}
