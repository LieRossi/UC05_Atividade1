using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Animator anim;
    private Rigidbody2D rb2d;

    public float Velocidade;
    //public float forcaPulo = 1000f;
    public bool viradoDireita = true;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {
        //Flip();
    }

    //gerenciar as animacoes
    private void FixedUpdate() {
        float translationY = 0;
        float translationX = Input.GetAxis("Horizontal") * Velocidade;
        transform.Translate(translationX, translationY, 0);

        if (translationX != 0) {
            anim.SetTrigger("correndo");
        } else {
            anim.SetTrigger("parado");
        }

        if (translationX > 0 && !viradoDireita) {
            Flip(); ;

        } else if (translationX < 0 && viradoDireita) {
            Flip();
        }

    }

        public void Flip() {
            viradoDireita = !viradoDireita;
            Vector3 escala = transform.localScale;
            escala.x *= -1;
            transform.localScale = escala;
        }
    }