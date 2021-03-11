using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    //Atributos
    public float vel;
    private Vector2 direcao;
    public Animator anim;
    private Rigidbody2D playerRB;
    private bool face = true;
    private Vector2 direcaoHeroi;
    private float x;
    private float y;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        direcao = Vector2.zero;
        anim = GetComponent<Animator>();

    }

    
    void Update()
    {
        //movimentacao do Personagem 
        playerRB.MovePosition(playerRB.position + direcao * vel * Time.deltaTime);
        InputPersonagem();
    }


    void InputPersonagem()
    {
        direcao = Vector2.zero;


        if (direcaoHeroi.x == 0 || direcaoHeroi.y == 0)
        {
            anim.SetFloat("X", Mathf.Abs(0));
            anim.SetFloat("Y", Mathf.Abs(0));
            direcao = Vector2.zero;
        }

        if (Input.GetKey(KeyCode.UpArrow))

        {
            direcao += Vector2.up * 2.0f;
            direcaoHeroi = direcao;
            anim.SetFloat("Y", Mathf.Abs(direcaoHeroi.y));
        }


        if (Input.GetKey(KeyCode.DownArrow))
        {
            direcao += Vector2.down * 2.0f;
            direcaoHeroi = direcao;
            anim.SetFloat("Y", direcaoHeroi.y);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            direcao += Vector2.left * 2.0f;
            direcaoHeroi = direcao;
            anim.SetFloat("X", Mathf.Abs(direcaoHeroi.x));

            if (direcaoHeroi.x < 0 && face)
            {
                Lado();
            }
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            direcao += Vector2.right * 2.0f;

            direcaoHeroi = direcao;
            anim.SetFloat("X", Mathf.Abs(direcaoHeroi.x));


            if (direcaoHeroi.x > 0 && !face)
            {
                Lado();
            }
        }
    }

    //modifica o lado do personagem
    void Lado()
    {
        face = !face;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }




}
