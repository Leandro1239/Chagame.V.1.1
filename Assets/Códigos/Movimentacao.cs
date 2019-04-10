using UnityEngine;

public class Movimentacao : MonoBehaviour {
       
    /*int moedas = 0;                      //MOEDA
    public TextMesh Total_Moeda;*/

    public Rigidbody2D player;

    int velocidade = 5;
    int forcapulo = 200;
    int direcao = 0;

    private bool olhandodireita = true;
    private bool pisandochao = false;

    void Start ()                                               //Jogador
    {
        player = gameObject.GetComponent<Rigidbody2D>();
    }

    void Flip()
    {
        olhandodireita = !olhandodireita;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Update()
    {
        transform.Translate(new Vector3((direcao * velocidade) * Time.deltaTime, 0, 0));
    }

    public void Direita()
    {
        direcao = 1;

        if (direcao > 0 && olhandodireita == false)
        {
            Flip();
        }
    }

    public void Esquerda()
    {
        direcao = -1;

        if (direcao < 0 && olhandodireita == true)
        {
            Flip();
        }
    }

    public void Para()
    {
        direcao = 0;
    }

    public void Pula()
    {
        if (pisandochao)                            //PULA com o botão
        {
            player.AddForce(new Vector2(0, forcapulo));                                         //SAI DO CHÃO                                                              //CONTATO COM O CHAO
            pisandochao = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D Chao)
    {
        if (Chao.gameObject.CompareTag("Chao"))
        {
            pisandochao = true;
        }
    }

    /*public void OnTriggerEnter2D(Collider2D coletar)                         //COLETA E CONTA MOEDA
    {
        if (coletar.gameObject.CompareTag("coin"))
        {
            Destroy(coletar.gameObject);
            moedas += 1;
            Total_Moeda.text = moedas.ToString();
        }
    }*/
}     
