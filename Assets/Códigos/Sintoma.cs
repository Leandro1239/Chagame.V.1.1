using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Sintoma : MonoBehaviour {

    public Image BarraVida;
   // public Text Quantidade;
    int ValorAtual = 100;
    int Dano = 33;
    int Energia = 66;

    public void OnCollisionEnter2D(Collision2D Dano)                        //TOMOU DANO
    {
        if (Dano.gameObject.CompareTag("Inimigo"))              
        {
            Destroy(Dano.gameObject);
            VidaPerde();
        }
    }

    public void OnTriggerEnter2D(Collider2D Vida)                         //GANHA VIDA AO PASSAR NA BARRACA
    {
        if (Vida.gameObject.CompareTag("Vida"))
        {
            VidaGanha();
        }
    }


    public void VidaPerde()
    {
        if (ValorAtual > 0)
        {
            ValorAtual -= Dano;
            BarraVida.fillAmount = (float)ValorAtual/100;
            //string temp = ValorAtual.ToString();
            //Quantidade.text = temp;
            if (ValorAtual == 1)                    //MORREU
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public void VidaGanha()
    {
        if (ValorAtual < 100)
        {
            ValorAtual += Energia;
            BarraVida.fillAmount = (float)ValorAtual / 100;
            //string temp = ValorAtual.ToString();
            //Quantidade.text = temp;
        }
        MaxVida();
    }

    void MaxVida()
    {
        if (ValorAtual > 100)
        {
            ValorAtual = 100;
        }
    }
}
