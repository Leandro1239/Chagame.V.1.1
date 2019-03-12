using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimentacao : MonoBehaviour {
       
    int moedas = 0;                      //MOEDA
    public TextMesh Total_Moeda;

    float forca = 20;                           //JOGADOR
    float VelocidadeAceleração = 10;
    public Rigidbody2D player;
    private bool tocachao = false;
    Rigidbody2D rigd = new Rigidbody2D();           
    

    public Transform checachao;                     //CHÃO
    public LayerMask piso;
    float chaograu = 0.2f;
    

    public GameObject Largada;                      //RECORDE
    public TextMesh Total_Distancia;
    float distancia = 0;
    int recorde = 0;

    Animator anim;                                  //Animação

    void Start ()                                               //Jogador
    {
        player = GetComponent<Rigidbody2D>();
        rigd = gameObject.GetComponent <Rigidbody2D>();

        anim = GetComponent<Animator>();
    
	}

    private void Update()                                                       // MEDE A DISTANCIA E COLOCA EM 'RECORDE'
    {
        distancia = Vector2.Distance(Largada.transform.position, player.transform.position);
        recorde = (int)distancia;
        Total_Distancia.text = recorde.ToString();

        rigd.velocity = new Vector2(VelocidadeAceleração, rigd.velocity.y);               //FAZ CORRER SOZINHO
        tocachao = Physics2D.OverlapCircle(checachao.position, chaograu, piso);             //CONTATO COM O CHAO

        if (tocachao == false)
        {
            anim.SetBool("Pular", false);
            anim.SetBool("Correr", true);
        }
    }

    public void Pula()
    {
        if (tocachao)                            //PULA com o botão
        {
            player.AddForce(new Vector2(0, forca));                                         //SAI DO CHÃO
            anim.SetBool("Pular", true);
            anim.SetBool("Correr", false);
            VelocidadeAceleração = VelocidadeAceleração * 1.02f;                            //ATRIBUI O AUMENTO DA VELOCIDADE A CADA PULO
        }
    }

    /*public void OnCollisionEnter2D(Collision2D Chao)
    {
        if (Chao.gameObject.CompareTag("Chão"))
        {
            anim.SetBool("Pular", false);
            anim.SetBool("Correr", true);
        }
    }*/

    public void OnTriggerEnter2D(Collider2D ativar)                         //COLETA E CONTA MOEDA
    {
        if (ativar.gameObject.CompareTag("coin"))
        {
            Destroy(ativar.gameObject);
            moedas += 1;
            Total_Moeda.text = moedas.ToString();
        }
    }
}     
