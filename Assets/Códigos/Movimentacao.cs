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
    public bool tocachao = false;
    Rigidbody2D rigd = new Rigidbody2D();           
    

    //public Transform checachao;                     //CHÃO
    //public LayerMask piso;
    //float chaograu = 0.3f;
    

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

    private void Update()                                                       
    {
        distancia = Vector2.Distance(Largada.transform.position, player.transform.position);  // MEDE A DISTANCIA E COLOCA EM 'RECORDE'
        recorde = (int)distancia;
        Total_Distancia.text = recorde.ToString();

        rigd.velocity = new Vector2(VelocidadeAceleração, rigd.velocity.y);               //FAZ CORRER SOZINHO
        //tocachao = Physics2D.OverlapCircle(checachao.position, chaograu, piso);             //CONTATO COM O CHAO

    }

    public void Pula()
    {
        if (tocachao == true)                            //PULA com o botão
        {
            player.AddForce(new Vector2(0, forca));                                         //SAI DO CHÃO
            anim.SetBool("Pular", true);
            anim.SetBool("Correr", false);
            VelocidadeAceleração = VelocidadeAceleração * 1.02f;                            //ATRIBUI O AUMENTO DA VELOCIDADE A CADA PULO
            tocachao = false;                                                               //CONTATO COM O CHAO
        }
    }

    public void OnCollisionEnter2D(Collision2D Chao)
    {
        if (Chao.gameObject.CompareTag("Chão"))
        {
            tocachao = true;
            anim.SetBool("Pular", false);
            anim.SetBool("Correr", true);
        }

    }

    public void OnTriggerEnter2D(Collider2D coletar)                         //COLETA E CONTA MOEDA
    {
        if (coletar.gameObject.CompareTag("coin"))
        {
            Destroy(coletar.gameObject);
            moedas += 1;
            Total_Moeda.text = moedas.ToString();
        }
    }
}     
