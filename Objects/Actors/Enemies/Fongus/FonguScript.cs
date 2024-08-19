using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FonguScript : MonoBehaviour {
    [Header("Public")]


    [Header("SerializeField")]
    [SerializeField] FongusStates fongusState;
    [SerializeField] float offset;

    Rigidbody2D rb2d;
    Animator ani;
    GameObject target;
    EnemyScript enemyScript;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        //Obtenemos componentes
        ani = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        enemyScript = GetComponent<EnemyScript>();
        sr = GetComponent<SpriteRenderer>();    

        
    }

    // Update is called once per frame
    void Update()
    {

        if (PlayerManager.instance.transform.position.x < this.transform.position.x) {

            sr.flipX = true;
        } else if (PlayerManager.instance.transform.position.x > this.transform.position.x) {

            sr.flipX = false;
        }

        fongusPerception();
        fongusManager();
    }

    void fongusPerception() {
        if (Vector2.Distance(this.transform.position, PlayerManager.instance.transform.position) < offset) {
            fongusState = FongusStates.Attack;
        } else {
            fongusState = FongusStates.Iddle;
        }


        //Debug.Log(Vector2.Distance(this.transform.position, PlayerManager.instance.transform.position));
    }

    void fongusManager() {

        switch (fongusState) {

            case FongusStates.Iddle:
                fongusIddle();
                break;

            case FongusStates.Attack:
                fongusAttack();
                break;

        }
        
    }

    void fongusIddle() {
        ani.SetBool("isIddle", true);
        ani.SetBool("isAttacking", false);
        ani.SetBool("isRunning", false);
        ani.SetBool("IsTakingDamage", false);


    }

    void fongusAttack() {
        ani.SetBool("isAttacking", true);
        ani.SetBool("isIddle", false);
        ani.SetBool("isRunning", false);
        ani.SetBool("IsTakingDamage", false);

    }


    enum FongusStates {
        Iddle,
        Seek,
        Attack,
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            PlayerManager.instance.getDamage(enemyScript.damage);

        }
    }


}
